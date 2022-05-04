# Planner

A tool that enables developers and teams to design software applications, manage requirements and tasks, track progress, and meet deadlines. 

Integrated tracking system make projects and project components trackable and allows users and teams to achieve target metrics. Teams and Role features allow groups of developers to collaborate throughout the software development life cycle. Alert system reminds user when items are due or past due. 

Identity and role based access/rendering. Ticket system for tracking progress, requests, issues, and changes.

![My App](./app.png)

## WALKTHROUGH

Minimal Viable Product
- User can create PROJECT, REQUIREMENT, TASK
- User can create LISTs under PROJECT, REQUIREMENT, TASK

Other planned features
- PROJECT - Projects can be broken down into separate Requirements and further into Tasks.
	-- each PROJECT VIEW >> option to see -list of LISTs and TASKS
	-- each TASK VIEW >> -list of LISTs and TICKETs

- User access - allows users to assign notes and tasks to other users
- PROJECTs and TASKs assignments: assign to TEAM/TEAM or TEAM/USER (default is SELF). 
- Roles - project creators can delete or rename their project and lists other users can append notes to tickets or file a ticket to a project, requirement, or task
- CRUD Projects, Requirement, Task, User, Team
- Lists - used to draft and organize Project, Requirements, and Tasks. Items must be inserted into a Ticket to assign to another user. 
- Tickets - may be attached under PROJECT, REQUIREMENT, or TASK; NOTEs appended to Tickets. Each Ticket contains a list of NOTEs
- Attachments - may be attached to PROJECT, REQUIREMENT, TASK, and TICKETs
- Change history for PROJECT, REQUIREMENT, and TASK CRUD history
- Notification/Alerts when items are ASSIGNED and DUE
- Sort, Search, Filter projects, tasks, notes

DASHBOARD STATISTICS
- How many REQUIREMENTs/TASKs/TICKETs in PROJECT are
	-- complete 
	-- past due
	-- on time
	-- outstanding

Project Export notes - csv file

## OPEN REQUIREMENTS

- User login / registration
- Roles (User, Admin, Owner)
- CRUD Projects, Requirements, Task, User, Lists
- Notification when items are ASSIGNED and DUE
- Project statistics (timeline options)
- Sort / Search / Filtering
- Option to export project data to a csv file

TEAM is a designation, a descriptive way to segregate types of requirements, tasks, and tickets. TEAM designation is assigned by the creator of the TICKET. 

A PROJECT may contain a list of REQUIREMENTs.
A REQUIREMENT may contain a list of TASKs. 
A PROJECT, REQUIREMENT, and TASK may contain a list of TICKETs.
A TICKET is a list of NOTEs.

TICKETs can be created under: PROJECT, REQUIREMENT, and/or TASK.
	A TICKET may be modified or deleted by the user within 30 minutes of creation. After 30 minutes the user may only close the TICKET.
	TICKET types: Inquiry, Issue, Request, Update, Note

NOTEs may be appended to TICKETs, TASKs, REQUIREMENTs, and PROJECTs to update the status, note any progress/delays made since the last note, change due date, or update the status of the TICKET, TASKs, or PROJECT. 
	* notes cannot be modified or deleted after creation

## USER INTERFACE

- Landing (login/registration)
- Dashboard

--Profile--
- Image
- Role
- Assigned Projects, Tasks, Tickets
- Profile Management
- Project Management/History

Navigation:
- USER - list of open TICKETs assigned to USER and associated PROJECT under USER
- TASK - list TASKs assigned to USER, each TASK item populates a list of TICKETs/NOTEs and associated PROJECT
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

LIST
- Name
- Description
- IsComplete
- fk-User
- fk-Project
- fk-Requirement
- fk-Task

FILE
- FormFile
- FileName
- FileExtension
- FileData

NOTE
- Description
- Creator
- Date Created
-- option to upload/attach a file
-- option to change due date of ticket or close ticket

TICKET (Inquiry, Issue, Request, Update, Note)
- Title
- Description
- Creator
- Date Created
- Date Due (or Closed)
- Assigned Team (limit to teams available)
- Assigned User (limit to users in system)
- Status (New, Pending, Stale, Due, Closed)
- Archived
- Priority (None, Low, Important, Serious, Urgent)
- List-Notes>

TASK
- Title
- Description
- Creator
- Date Created
- Date Closed
- Date Due
- Status (New, Pending, Stale, Due, Closed)
- Archived
- List-Tickets>

PROJECT
- Title
- Details
- Creator
- Date Created
- Date Closed
- Date Due
- Status (New, Active, Stale, Closed)
- Archived
- List-Requirements>
- List-Tasks>
- List-Tickets>
