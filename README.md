# WindowsService
A demo windows service using .Net 5. Running will add a log in the event
viewer every second, and when it terminates.

# Installation
1. Clone the repo to your local machine
2. Publish the project to a folder
3. Run the following commands from an admin command prompt:

```
sc create "My Service Name" binPath="C:\Directory\Path\file.exe C:\Directory\Path"
sc start "My Service Name"
```