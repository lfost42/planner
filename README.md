# Software Planner

A tool that enables developers and teams to design software applications, manage requirements/tasks, track progress, and meet deadlines. 

Integrated tracking system make projects and project components trackable and allows users and teams to achieve target metrics. Teams and Role features allow groups of developers to collaborate throughout the software development life cycle.

Implements identity and role based access/rendering. SOLID principles demonstrated via object and record data structures. 

![My App](./app.png)

## WALKTHROUGH

- Teams
- Projects
- Requirements
- Tasks
- Tickets
- Notes

- Projected
- Issues & Notes (once project begins)
- Attachments
- History of changes
- Notes
- Priority


## OPEN REQUIREMENTS

- User login / registration
- Assigned role (assign/unassign for admins)

- CRUD Projects, Requirements, Tasks
- Assign projects, requirements, tasks, tickets to teams, roles, users
- Notifications when items are assigned
- Project statistics (timeline options)
- Sort / Search / Filtering
- Option to export project data to a csv file


## USER INTERFACE

- Landing (login/registration)
- Dashboard

--Profile
- Image
- Role
- Assigned Projects, Tasks, Tickets

- Profile Management
- Role Management
- Project Management
- Ticket Management

### LOGIC DESIGN

- Identity access
- Role based security
- Role based rendering
- Tracking for:
	- requirements
	- tasks
	- tickets
	- notes

### DATA DESIGN

- Roles
- UserModel
- ProjectModel

- History
- Types

- RequirementModel
- TaskModel
- TicketModel
- NoteModel

(one-to-many relationships >>)
- Requirements >> Tasks >> Tickets >> Notes 
	- int ID
	- str Name
	- enum Priority
	- enum Status
	- UserModel UserCreated
	- UserModel UserAssigned
	- Date DateCreated
	- Date DateUpdated
	- Date DateClosed
