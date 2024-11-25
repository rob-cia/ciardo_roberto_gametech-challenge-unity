# ciardo_roberto_gametech-challenge-unity

## Description
This project provides a graphical interface and a set of functions to manage push notifications in Unity. It focuses on sending a series of scheduled notifications, with a total of **5 notifications sent at one-minute intervals**.

---

## Features

### **UI**
#### *TAG: Unity-Schedule-Notifications*
- Includes a **"SCHEDULE NOTIFICATION"** button created using TextMeshPro (TMPro).
- Simple graphical layout for in-app visualization.

<img src="https://github.com/user-attachments/assets/34cdbb77-71ec-41fd-878e-12fe0f10f6aa" alt="layout" width="200"/>

___

#### *TAG: Unity-Remove-Notifications*
- Includes a **"REMOVE NOTIFICATION"** button created using TextMeshPro (TMPro).
- Reorganization of the hierarchy
- Creation of a footer at the bottom with centering of the buttons.

<img src="https://github.com/user-attachments/assets/704fd597-164a-4d90-9bf3-8b25ebd0b384" alt="layout" width="200"/>

#### *TAG: Unity-Touched-Notification-Data*
- Includes an header layout with notification information about the touched data.
- Creation of an header at the top with centering of the title app and notification informations.

<img src="https://github.com/user-attachments/assets/84286909-56cf-4bff-bd4a-ece94848f71b" alt="layout" width="200"/>

___

---

### **Scripts**

#### *TAG: Unity-Schedule-Notifications*

#### **Schedule Notifications**
- **Method**: `void ScheduleNotifications()`
- **Description**: Schedules the delivery of 5 notifications, each sent at one-minute intervals.

#### **Get Unity Activity**
- **Method**: `AndroidJavaObject GetUnityActivity()`
- **Description**: Retrieves Unity's `Activity`, required for interaction with the Android framework.
- **Returns**: The `currentActivity` object of the `com.unity3d.player.UnityPlayer` class.

#### **AndroidManifest**
- **Description**: Customized configuration for managing notifications.
- **Required permissions**:
  - `android.permission.SCHEDULE_EXACT_ALARM`
  - `android.permission.SET_ALARM`
- **BroadcastReceiver**:
  - Configured to securely handle explicit intents with:
    - `android:enabled="true`.
    - `android:exported="false`.

___

#### *TAG: Unity-Remove-Notifications*
#### **Remove Notifications**
- **Method**: `void RemoveNotifications()`
- **Description**: Call the plugin's removeNotification function
- **Details**: Removes all notifications scheduled in the future.

___

#### *TAG: Unity-Touched-Notification-Data*

#### **Notification Receiver**
- **Method**: `UpdateNotificatioUI()`
- **Description**: 
  Updates the UI to display the notification content (title, description, and icon) if available.
- **Details**:
  - Retrieves notification data (title, description, and icon) using the `GetNotificationData()` method.

#### **On Application Focus**
- **Method**: `OnApplicationFocus(bool hasFocus)`
- **Description**: 
  Updates the notification UI whenever the application regains focus.
- **Details**:
  - Calls `UpdateNotificatioUI()` when the application gains focus to ensure that the most recent notification is displayed.

#### **Get Notification Data**
- **Method**: `GetNotificationData(string key)`
- **Description**: 
  Retrieves notification data (title, description, or icon) from the incoming `Intent`.
- **Parameters**:
  - `string key`: The key to retrieve the specific data (`"title"`, `"description"`, or `"icon"`).
- **Details**:
  - Uses Android's `Intent` system to retrieve the specified data from the notification that triggered the receiver.
  - Calls `getStringExtra` on the `Intent` to fetch the value associated with the provided key.

---

## Requirements
- **Unity Version**: 2022.3.23f1
- **Target Platform**: Android
- **Minimum API Level**: 24 (Android 7.0)
- **Scripting Backend**: IL2CPP
