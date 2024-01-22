Morning Team Checklist

Assumptions: 
1. UserId mocked on the controller level and can be extracted and replaced from HttpContext later
2. Morning checklist is available all the time, "Morning" meaning that it resets in the morning
3. Assumed that all the users are in the same timezone to simplify development
5. Assumed that checklist/items history can be tracked separately so we are not creating new checklists/items during reset
6. Added "Reset" button to UI for easier testing

Setup and run:
1. Build dotnet solution repos\TeamChecklist\backend-services\TeamChecklist
1. Run Db migrations from the same folder "dotnet-ef database update  --context "TeamChecklistDbContext" --project TeamChecklist.Infrastructure --startup-project TeamChecklist.WebApi"
startup-project TeamChecklist.WebApi
2. Run WebApi backend app on http launch profile (http://localhost:5236)
3. Run JobWorker backend app
4. Run "npm i" under repos\TeamChecklist\client-apps\team-checklist-app
4. Run Angular frontend app with "npm start"

Testing:
1. All the actions can be tested from Angular app UI including the Reset checklist
2. To run Reset checklist daily job you can update repos\TeamChecklist\backend-services\TeamChecklist\TeamChecklist.JobsWorker\appsettings.json ResetChecklistsJobSchedule - HourOfTheDay, MinuteOfTheDay with your current day/time + 1 minute if right now it is 2.30 PM the values will be 14 and 31.
