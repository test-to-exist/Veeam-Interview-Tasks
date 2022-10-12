# Veenam Interview Tasks

## Build Project
After cloning a repository run in the root folder (Veeam-Interview-Tasks):

```
dotnet restore Veeam-Interview-Tasks.sln
dotnet build Veeam-Interview-Tasks.sln
```

## To run specific tasks

### 1. Process Monitoring App task

This one will check chrome with interval 1 minute and close after 2 minutes of chrome running 

```
cd ProcessMonitoringAppTask
dotnet run chrome 2 1
```


### 2. Selenium Vacancies Page test
2.1 This one will run in headless mode

```
cd SeleniumTask
dotnet test
```

2.2 This one will run in headed mode

- First remove "--headless" from "driverOptions" property in appsettings.json, the appsettings.json should look like this 

    ```
    {
        "defaultDriver": "Chrome",
        "driverOptions": [
        ],
        "defaultWaitForElement": 60,
        "baseUrl": "https://cz.careers.veeam.com"
    }
    ```

- Then simply

    ```
    cd SeleniumTask
    dotnet test
    ```

