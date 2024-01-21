Morning Team Checklist

Assumptions: 
1. We assume that each team member has a unique Username and mock it in the controller to skip working with the auth
2. Morning checklist is available all the time, "Morning" meaning that it resets in the morning
3. Decided to not go with a background job that automatically resets the checklist at 12 AM every day
4. Assumed that all the users are in the same timezone to simplify development
5. Assumed that checklist/items history can be tracked separately
6. Added "Reset" button to UI for easier testing

Setup:
1. Run Db migrations dotnet-ef database update "InitDatabase" --context "TeamChecklistDbContext" --project TeamChecklist.Infrastructure --
startup-project TeamChecklist.WebApi
2. Run WebApi backend app on http launch profile
3. Run JobWorker backend app
4. Run Angular frontend app

