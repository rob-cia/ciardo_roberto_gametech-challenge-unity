# ciardo_roberto_gametech-challenge-unity

## Description
This project provides a graphical interface and a set of functions to manage push notifications in Unity. It focuses on sending a series of scheduled notifications, with a total of **5 notifications sent at one-minute intervals**.

---

## Features

### **UI**
- Includes a **"SCHEDULE NOTIFICATION"** button created using TextMeshPro (TMPro).
- Simple graphical layout for in-app visualization.

<img src="https://github.com/user-attachments/assets/34cdbb77-71ec-41fd-878e-12fe0f10f6aa" alt="layout" width="200"/>

---

### **Scripts**

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

---

## Requirements
- **Unity Version**: 2022.3.23f1
- **Target Platform**: Android
- **Minimum API Level**: 24 (Android 7.0)
- **Scripting Backend**: IL2CPP
