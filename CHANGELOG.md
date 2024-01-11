# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

# Guiding Principles
- Changelogs are for humans, not machines.
- There should be an entry for every single version.
- The same types of changes should be grouped.
- Versions and sections should be linkable.
- The latest version comes first.
- The release date of each version is displayed.
- Mention whether you follow Semantic Versioning.

# Types of changes
- **Added** for new features.
- **Changed** for changes in existing functionality.
- **Deprecated** for soon-to-be removed features.
- **Removed** for now removed features.
- **Fixed** for any bug fixes.
- **Security** in case of vulnerabilities.

---

## [Unreleased] - 2024-01-11

### ADDED
- RandomParametersGenerator method in LoadControl.

---

## [Unreleased] - 2024-01-11

### FIXED
- Call the _serialHandler.Connect method when saving port settings.

---

## [Unreleased] - 2024-01-11

### REMOVED
- GetTempCelsius method in SerialDataAcquisition.

---

## [Unreleased] - 2023-12-03

### CHANGED
- Save method for asynchronous with data model list as parameter in CSVService.
- Creates the file and saves the first data with a header and then adds the data without a header.
- Types of data saving model properties changed to string.

---

## [Unreleased] - 2023-11-29

### ADDED
- Class responsible for saving csv file in service.
- Asynchronous method to save data to csv file in CSV Service class.

---

## [Unreleased] - 2023-11-22

### ADDED
- DataBaseModel to save data in CSV file.
- The model contains the Temperature and the reading moment.

---

## [Unreleased] - 2023-11-20

### ADDED
- Column to configure database parameters.
- Monitoring Radio button.
- Standby Radio button.

---

## [Unreleased] - 2023-11-20

### FIXED
- The task was not being closed correctly when changing the pause and work times.
- Cancellation token added to delay.
- Closes the task before updating the parameters.

---

## [Unreleased] - 2023-11-18

### ADDED
- SerialHandler added in LoadController.
- Implement WorkRoutine method in LoadController.
- Implement PauseRoutine method in LoadController.
- Implement SendCommand method in SerialDataAcquisition.

---

## [Unreleased] - 2023-11-12

### ADDED
- Set Parameters Model.
- Sending parameters to load controller class.

---

## [Unreleased] - 2023-11-12

### ADDED
- Method that applies the parameters on the set parameters page implemented.

---

## [Unreleased] - 2023-11-12

### ADDED
- Load Controller class.
- Load Control Routine task.
- Work routine method.
- Pause routine method.
- Start method.
- Stop method.
- SetParameters.

---

## [Unreleased] - 2023-11-12

### FIXED
- Exception when updating temperature value in gauge.

---

## [Unreleased] - 2023-11-12

### FIXED
- Loading saved port name on the settings page.
- Loading saved baud rate on the settings page.

---

## [Unreleased] - 2023-11-12

### CHANGED
- Enum to boolean convert modified in the method that changes between themes on the settings page

---

## [Unreleased] - 2023-11-12

### ADDED
- Duty cycle parameter.
- Work duration parameter.
- Pause duration parameter.
- Work mode.
- Switching between work modes.

---

## [Unreleased] - 2023-11-12

### CHANGED
- Enum to boolean converter modified to be more generic for any type of enum.

---

## [Unreleased] - 2023-11-09

### ADDED
- Set parameters view and view model.
- Set parameters added in dependece injection.

---

## [Unreleased] - 2023-11-09

### FIXED
- Updates the gauge only if the temperature value is less than 100.

---

## [Unreleased] - 2023-11-09

### ADDED
- Update temperature event.
- Updating gauge value with value received by serial.

---

## [Unreleased] - 2023-11-09

### ADDED
- Serial data received event.
- Serial decode method.
- Method to convert temperature to celsius.

---

## [Unreleased] - 2023-11-09

### ADDED
- File.settings to save settings.
- Button to save port settings on the settings page.
- Method to connect to a serial port through saved port settings.

---

## [Unreleased] - 2023-11-07

### ADDED
- Baud Rate and Selected Baud rate properties.
- Filling baud rate comboBox on the settings page.

---

## [Unreleased] - 2023-11-07

### ADDED
- IService and Service added as sigleton.
- GetPortNames serial method created.
- Behaviors added to binding events.
- Service added on settings page.
- Filling in the port names comboBox.
- Updating port names when opening comboBox.

---

## [Unreleased] - 2023-11-07

### ADDED
- Class to acquire serial data.

---

## [Unreleased] - 2023-11-07

### ADDED
- Port name and baud rate for connecting to the Arduino added to the settings page.

---

## [Unreleased] - 2023-11-05

### ADDED
- Livecharts2 package.
- Gauge chart to display temperature in degrees Celsius using LiveCharts2 on the Home page.

---

## [Unreleased] - 2023-11-05

### CHANGED
- Dashboard page was deleted and replaced by the homepage.

---

## [Unreleased] - 2023-11-05

### CHANGED
- Project icon changed to temperature gauge.
- Removed WPFUI icon and images.

---

## [Unreleased] - 2023-11-05

### FIXED
- Bug in Navigatio view background color when switching between dark and light theme.

---

## [Unreleased] - 2023-11-05

### ADDED
- Method to get the assembly title.
- Method to get the assembly version.
- About property.

---

## [Unreleased] - 2023-11-05

### ADDED
- Additional information in AssemblyInfo.

---

## [Unreleased] - 2023-11-05

### CHANGED
- Open Pane Length.

---

## [Unreleased] - 2023-11-05

### REMOVED
- Search box removed from navigation pane.

---

## [Unreleased] - 2023-11-04

### CHANGED
- Starting with navigation panel closed.

---

## [Unreleased] - 2023-11-04

### REMOVED
- Navigation view Back button removed.

---

## [Unreleased] - 2023-11-04

### ADDED
- TitleBar and NavigationView in separate grids.

---

## [Unreleased] - 2023-11-04

### ADDED
- The window color is independent of the operating system's custom color.

---

## [Unreleased] - 2023-11-04

### ADDED
- .gitignore file.
- Changelog file.
- WPF UI Template project, the extension can be found via the link https://marketplace.visualstudio.com/items?itemName=lepo.wpf-ui 