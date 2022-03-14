# Software Planner

A tool that enables developers and teams to design software applications, manage tasks, track progress, and meet deadlines. 

Integrated tracking system make projects and project components trackable and allows users and teams to achieve target metrics. Teams and Role features allow groups of developers to collaborate throughout the software development life cycle.

Identity and role based access/rendering. Ticket system for tracking progress, requests, issues, and changes.

![My App](./app.png)

## WALKTHROUGH

Minimal Viable Product
- Single project/user app
- User create TASKs
- User attach NOTEs to TASKs or PROJECT and assign to self

Other planned features
- PROJECT - allows users to create projects and assign tasks under the project, users may view all tasks and notes by PROJECT. Create TEAMs for PROJECT. 
	-- each PROJECT VIEW >> option to see list of TASKS or list of NOTEs
	-- each TASK VIEW >> list of NOTEs

- User access - allows users to assign notes and tasks to other users
- PROJECTs and TASKs assignments: assign to TEAM/TEAM or TEAM/USER (default is SELF). 
- Roles - project creators can delete or rename their project, other users can append notes and tickets to them
- CRUD Projects, Task, User
- Tickets - may be attached under PROJECT or TASK, NOTEs assigned to Tickets. Each Ticket contains a list of NOTEs
- Attachments - may be attached to PROJECT, TASK, and TICKETs
- Change history for PROJECT and TASK CRUD history
- Notification/Alerts when items are ASSIGNED and DUE
- Sort, Search, Filter projects, tasks, notes

DASHBOARD STATISTICS
- How many TASKs/NOTEs in PROJECT are
	-- complete 
	-- past due
	-- on time
	-- outstanding

Project Export - csv file

## OPEN REQUIREMENTS

- User login / registration
- Roles (User, Admin, Owner)
- CRUD Projects, Task, User
- Notification when items are ASSIGNED and DUE
- Project statistics (timeline options)
- Sort / Search / Filtering
- Option to export project data to a csv file

TEAM is a designation, a descriptive way to segregate types of tasks and tickets. TEAM designation is assigned by the creator of the TICKET. 

A PROJECT may contain a list of TASKs. 

TICKETs can be created under: PROJECT and/or TASK.
	A TICKET may be modified or deleted by the user within 30 minutes of creation. After 30 minutes the user may only close the TICKET.
	TICKET types: Inquiry, Issue, REquest, Update, Note

NOTEs may be appended to TICKETs, TASKs, and PROJECTs to update the status, note any progress/delays made since the last note, change due date, or update the status of the TICKET, TASKs, or PROJECT. 
	* notes cannot be modified or deleted after creation

## USER INTERFACE

- Landing (login/registration)
- Dashboard

--Profile
- Image
- Role
- Assigned Projects, Tasks, Tickets
- Profile Management
- Project Management/History

Navigation:
- USER - list of open TICKETs assigned to USER and associated PROJECT under USER
- TASK - list TASKs assigned to USER, each TASK item populates a list of TICKETs and associated PROJECT
- PROJECT - list of TICKETs
- TEAM - list TEAMs, each TEAM item populates a list of TICKETs and associated PROJECT

### LOGIC DESIGN

- Identity access
- Role based security
- Role based rendering

### DATA DESIGN

USER
- FirstName
- LastName

CREATOR
- User

FILE
- FormFile
- FileName
- FileExtension
- FileData

NOTE
- Description
- Creator
- Date Created
- > option to upload/attach a file
- > option to change due date of ticket or close ticket

TICKET (Inquiry, Issue, Request, Update, Note)
- Title
- Description
- Creator
- Date Created
- Date Due (or Closed)
- Assigned Team (limit to teams available)
- Assigned User (limit to users in system)
- Status (New, Pending, Stale Closed)
- Priority (None, Low, Important, Serious, Urgent)
- List-Notes>

TASK
- Title
- Description
- Creator
- Date Created
- Date Closed
- Status (New, Active, Stale, Closed)
- List-Tickets>

PROJECT
- Title
- Details
- Creator
- Date Created
- Date Closed
- Status (New, Active, Stale, Closed)
- List-Tasks>
- List-Tickets>
