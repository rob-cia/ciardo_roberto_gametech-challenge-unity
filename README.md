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

___

#### *TAG: Unity-Remove-Scheduled-Notification*
- Includes a new fixed button layout on each notification that allows you to dismiss it.
- Editing a prefab to handle notifications.

<img src="https://github.com/user-attachments/assets/e4217023-fdf2-4866-abe7-47a736eed0e6" alt="layout" width="200"/>
<img src="https://github.com/user-attachments/assets/0b108510-d7f5-4741-9581-eb768e436b80" alt="layout" width="200"/>

___

#### *TAG: Unity-Change-Notifications-Schedule*
- Includes a new fixed progress bar layout on each notification that allows you to monitor the sending progress.
- Modified the Notification prefab to handle notifications through a Layout Element and a Canvas Group.
- Creating the NotificationSpacing prefab to handle the space under the notification during drag and drop

<img src="https://github.com/user-attachments/assets/ef8006d7-8dce-405e-90d4-b581585f760f" alt="layout" width="200"/>
<img src="https://github.com/user-attachments/assets/a1e89392-1d8c-4ae4-bf59-5a2a2389934e" alt="layout" width="200"/>
<img src="https://github.com/user-attachments/assets/f305028c-2cec-4f77-b96d-6518696b4c4d" alt="layout" width="200"/>

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

___

#### *TAG: Unity-Remove-Scheduled-Notification*

#### **On Button Click Remove Notification**
- **Method**: `OnButtonClickRemoveNotification()`
- **Description**: Handles the removal of a specific notification when a UI button is clicked in Unity.
- **Details**:
  - Checks if `_notificationId` is valid (`NULL_ID` check) before proceeding.
  - Calls the Android plugin method `removeNotificationById` via `AndroidJavaClass`:
    - Passes the Unity activity and `_notificationId` to the Android layer.
  - Triggered by a Unity "deleteButton"'s `OnClick` event.

___

#### *TAG: Unity-Change-Notifications-Schedule*

---

#### **DropZone Component**
- **Class**: `DropZone`
- **Description**: A Unity MonoBehaviour script that enables a GameObject to act as a drop zone for draggable objects, supporting drag-and-drop functionality using Unity's Event System.
- **Details**:
  - Implements the following interfaces:
    - `IDropHandler`: Handles object drop logic.
    - `IPointerEnterHandler`: Detects when a pointer enters the drop zone.
    - `IPointerExitHandler`: Detects when a pointer exits the drop zone.
- **Method**:
  - `void OnPointerEnter(PointerEventData eventData)`
    - **Description**: Updates the placeholder's parent transform to the current drop zone when a draggable object enters the zone.
  - `void OnPointerExit(PointerEventData eventData)`
    - **Description**: Resets the placeholder's parent transform to its original parent when the pointer exits the drop zone.
  - `void OnDrop(PointerEventData eventData)`
    - **Description**: Handles the logic when a draggable object is dropped onto the drop zone.
   
---

#### **Draggable Component**
- **Class**: `Draggable`
- **Description**: A Unity MonoBehaviour script enabling drag-and-drop functionality for UI elements, including placeholder management and interaction with a `NotificationManager`.
- **Details**:
  - Implements the following interfaces:
    - `IBeginDragHandler`: Handles actions when dragging begins.
    - `IDragHandler`: Handles updates while dragging.
    - `IEndDragHandler`: Handles actions when dragging ends.
  - Supports placeholder management to maintain layout integrity during dragging.
  - Interacts with the `NotificationManager` to update notification order after drag-and-drop operations.
- **Method**:
  - **`void OnBeginDrag(PointerEventData eventData)`**
    - **Description**: Initializes the drag operation.
    - **Details**:
      - Creates a placeholder to maintain layout consistency.
      - Stores the parent transforms (`parentToReturnTo` and `placeHolderParent`) for later restoration.
      - Temporarily moves the dragged object to a higher-level parent for better UI control.
      - Disables raycasting on the dragged object to allow interaction with drop zones.
  
  - **`void OnDrag(PointerEventData eventData)`**
    - **Description**: Updates the position of the dragged object and adjusts the placeholder's position.
    - **Details**:
      - Moves the object to follow the pointer.
      - Ensures the placeholder is reparented if its parent changes.
      - Dynamically determines the placeholder's new sibling index based on the dragged object's position relative to other siblings.
  
  - **`void OnEndDrag(PointerEventData eventData)`**
    - **Description**: Finalizes the drag operation.
    - **Details**:
      - Restores the dragged object to its original parent (`parentToReturnTo`).
      - Sets the object's position based on the placeholder's sibling index.
      - Destroys the placeholder.
      - Calls `UpdateOrder` to notify the `NotificationManager` of any changes.
  
  - **`void UpdateOrder()`**
    - **Description**: Notifies the `NotificationManager` to update the order of notifications.
    - **Details**:
      - Ensures that a `NotificationManager` is assigned in the inspector.
      - Calls `UpdateOrderOnDragAndDrop` on the `NotificationManager` to propagate changes.
  
  - **`bool IsDragging()`**
    - **Description**: Checks if the object is currently being dragged.
    - **Returns**: `true` if dragging is in progress, otherwise `false`.
  
  - **`void CancelDrag()`**
    - **Description**: Cancels the drag operation and restores the object to its original state.
    - **Details**:
      - Restores the object's parent and sibling index.
      - Re-enables raycasting.
      - Destroys the placeholder.

---

#### **Update Order On Drag And Drop**
- **Method**: `UpdateOrderOnDragAndDrop()`
- **Description**: Updates the order of notifications after a drag-and-drop operation is completed, synchronizing with the Android plugin.
- **Details**:
  - Collects the `NotificationProperties` components of all child notifications.
  - Extracts their `_notificationId` values into an integer array for processing.
  - Calls the `updateOrderOnDragAndDrop` method of the Android plugin, passing the Unity activity and the array of notification IDs to update the order on the Android side.
  - Triggered when a drag-and-drop action is completed in the UI (`OnEndDrag()`).

---

#### **Update Order UI**
- **Method**: `UpdateOrderUI()`
- **Description**: Updates the UI to reflect the correct order of notifications based on their `order` property and visibility status.
- **Details**:
  - Separates notifications into visible and hidden lists based on their `activeSelf` property.
  - Sorts both lists according to the notification's `GetOrder()` value.
  - Combines the sorted lists and sets the sibling index for each notification to update their order in the UI.
  - Triggered when the UI needs to be refreshed at the start of application.

---

#### **Reset Order Notification UI**
- **Method**: `ResetOrderNotificationUI()`
- **Description**: Resets the UI order of notifications to their original state.
- **Details**:
  - Loops through all notifications and resets their sibling index to match the original order in which they were added.
  - Triggered when the UI needs to be reset at the button send event click.

---

#### **Update Notification UI** (UPDATED)
- **Method**: `UpdateNotificatioUI()`
- **Description**: Updates the Unity UI to reflect the current state of scheduled notifications retrieved from the Android plugin.
- **Details**:
  - Retrieves the list of scheduled notifications from the native Android plugin via `getScheduledNotifications`.
  - For each notification in the retrieved data:
    - Extracts relevant details such as the notification ID, title, description, icon, trigger time, and status.
    - If the notification status is "cancelled":
      - Deactivates the notification in the UI.
      - Cancels any ongoing drag operation for that notification.
    - If the notification is not cancelled:
      - Calculates the progress based on the difference between the trigger time and the current time, updating the progress bar.
      - Updates the UI components of the notification (ID, title, description, icon, and order).
      - Activates the notification in the UI.

---

## Requirements
- **Unity Version**: 2022.3.23f1
- **Target Platform**: Android
- **Minimum API Level**: 24 (Android 7.0)
- **Scripting Backend**: IL2CPP
