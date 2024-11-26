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

___

#### *TAG: Unity-Touched-Notification-Data*
- Includes an header layout with notification information about the touched data.
- Creation of an header at the top with centering of the title app and notification informations.

<img src="https://github.com/user-attachments/assets/84286909-56cf-4bff-bd4a-ece94848f71b" alt="layout" width="200"/>

___

#### *TAG: Unity-List-Scheduled-Notifications*
- Includes a content layout with the 5 notification information. A 1-column grid is used.
- Creating a prefab for notification handling.

<img src="https://github.com/user-attachments/assets/50a27446-5b32-4084-b6b0-a49e445259bd" alt="layout" width="200"/>
<img src="https://github.com/user-attachments/assets/37ae6f15-76d4-4709-8096-1966df8bb82e" alt="layout" width="200"/>


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

____

#### *TAG: Unity-List-Scheduled-Notifications*

#### **Notification Properties Management**
- **Class**: `NotificationProperties`
- **Description**: Manages the properties of a single notification, including its ID, title, description, and icon. Provides initialization and update methods for UI elements.
- **Details**:
  - Dynamically retrieves and sets notification properties, such as text and icon, from Unity UI components.
  - Supports a predefined list of icons (`_iconArray`) for efficient icon management.
- **Serialized Fields**:
  - `Texture2D[] _iconArray`: An array of icon textures used to display notification icons.
- **Private Fields**:
  - `int _notificationId`: Unique identifier for the notification.
  - `TMP_Text _titleText`: Reference to the UI text component for the notification title.
  - `TMP_Text _descriptionText`: Reference to the UI text component for the notification description.
  - `RawImage _iconRawImage`: Reference to the UI image component for the notification icon.

#### **Update Notification UI**
- **Method**: `UpdateNotificatioUI()`
- **Description**: Updates the Unity UI to reflect the current state of scheduled notifications retrieved from the Android plugin.
- **Details**:
  - Retrieves the list of scheduled notifications from the native Android plugin via `getScheduledNotifications`.
  - Parses notification data (e.g., ID, title, description, icon, and status) to update Unity UI components dynamically.
  - Hides cancelled notifications and displays active ones with appropriate details.
 
#### **Request Updated Data**
- **Method**: `RequestUpdatedData()`
- **Description**: Requests the updated data of scheduled notifications from the Android plugin when the app starts or when it gains focus.
- **Details**:
  - **Platform Check**: Executes only on Android platform (`RuntimePlatform.Android`).
  - Calls the static method `onStartup` from the Android plugin (`NotificationPlugin`) to refresh or synchronize notification data.
  - Ensures that the notifications are updated when the app is brought into focus or started.

---

## Requirements
- **Unity Version**: 2022.3.23f1
- **Target Platform**: Android
- **Minimum API Level**: 24 (Android 7.0)
- **Scripting Backend**: IL2CPP
