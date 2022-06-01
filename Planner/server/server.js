const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');

const app = express();

app.use(express.json());
app.use(cors());

mongoose.connect('mongodb://localhost:27017/task', {
	useNewUrlParser: true, 
	useUnifiedTopology: true 
}).then(() => console.log("Connected to MongoDB")).catch(console.error);

const Task = require('./models/Task')

app.get('/tasks', async (req, res) => {
	const tasks = await Task.find()
	res.json(tasks)
})

app.post('/task/new', (req, res) => {
	const task = new Task({
		text: req.body.text
	})
	task.save()
	res.json(task)
})

app.delete('/task/delete/:id', async (req, res) => {
	const result = await Task.findByIdAndDelete(req.params.id)
	res.json({result})
})

app.get('/task/complete/:id', async (req, res) => {
	const task = await Task.findById(req.params.id)
	task.complete = !task.complete
	task.save()
	res.json(task)
})

app.put('/task/update/:id', async (req, res) => {
	const task = await Task.findById(req.params.id)
	if (task.text != null) {
		task.text = req.body.text
	}
	task.save()
	res.json(task)
});

app.listen(3001)