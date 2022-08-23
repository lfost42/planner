import { useEffect, useState } from 'react';
const api_base = 'http://localhost:3001';

function App() {
	const [tasks, setTasks] = useState([]);
	const [popupActive, setPopupActive] = useState(false);
	const [newTask, setNewTask] = useState('');

	useEffect(() => {
		GetTasks();
	}, []);

	const GetTasks = () => {
		fetch(api_base + '/tasks')
			.then(res => res.json())
			.then(data => setTasks(data))
			.catch((err) => console.error('Error: ', err));
	}
  
	const completeTask = async id => {
		const data = await fetch(api_base + '/task/complete/' + id)
			.then(res => res.json());
		setTasks(tasks => tasks.map(task => {
			if (task._id === data._id) {
				task.complete = data.complete;
			}
			return task;
		}));
	}

	const addTask = async () => {
		const data = await fetch(api_base + '/task/new', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json' 
			},
			body: JSON.stringify({
				text: newTask
			})
		})
		.then(res => res.json());

		setTasks([...tasks, data]);
		setPopupActive(false);
		setNewTask('');
	}

	const deleteTask = async id => {
		const data = await fetch(api_base + '/task/delete/' + id, 
			{ 
				method: 'DELETE' 
			})
			.then(res => res.json());
		setTasks(tasks => tasks.filter
			(
				task => task._id !== data.result._id
				));
	}

	return (
		<div className='App'>
			<h1>Crudding With React</h1>
			<h4>Your tasks</h4>
			<div className='tasks'>
				{tasks.length > 0 ? tasks.map(task => (
					<div className={
						'task' + (task.complete ? ' is-complete' : '')
					} key={task._id} onClick={() => completeTask(task._id)}>
						<div className='checkbox'></div>

						<div className='text'>{task.text}</div>
						<div className='delete-task' onClick={() => deleteTask(task._id)}>x</div>
					</div>
				)) : (
					<p>You currently have no tasks</p>
				)}
			</div>

			<div className='addPopup' onClick={() => setPopupActive(true)}>+</div>
			{popupActive ? (
				<div className='popup'>
					<div className='closePopup' onClick={() => setPopupActive(false)}>X</div>
					<div className='content'>

						<h3>Add Task</h3>
						<input type='text' className='add-task-input' onChange={e => setNewTask(e.target.value)} value={newTask} />
						<div className='button' onClick={addTask}>Create Task</div>
					</div>
				</div>
			) : ''}

		</div>
	);
}

export default App;