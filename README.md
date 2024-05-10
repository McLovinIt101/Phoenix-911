# Phoenix 911 - FiveM Script 

A FiveM script providing a 911 emergency call system for roleplay servers using the Phoenix framework.

## Features

* **Player-Initiated Calls:** Players can use the `/911` command to send emergency calls with their current location.
* **LEO Notifications:** Law Enforcement Officers (LEOs) in specified departments receive 911 calls with the message and postal code of the incident.
* **Visual Notifications:**  911 calls and system responses are displayed prominently in the chat.
* **Postal Code Integration:** Provides postals for LEOs using the `nearest-postal` export.

## Installation

1. Download or clone this repository.
2. Place the `Phoenix-911` folder into your FiveM server's resources folder.
3. Add `ensure Phoenix-911` to your server configuration file (`server.cfg`).
4. **Dependency:** Ensure you have the `nearest-postal` resource installed and configured.

## Configuration

* **`validLeoDepartmentIds`:** Modify the set of department IDs that receive 911 notifications.

## Usage

1. In-game, players type `/911 [message]` to send an emergency call.
2. LEOs within the valid departments will receive the call notification.

## Contributing

We welcome contributions! Feel free to open issues for bug reports or feature suggestions. To submit code changes, please follow these steps:

1. Fork this repository.
2. Create a new branch.
3. Make your changes and commit them.
4. Open a pull request for review.

## TODO

* Add client-side input validation for the `/911` command.
* Implement a more sophisticated UI for displaying 911 call status.
* Add server-side authorization checks to restrict usage of the `/911` command.
* Explore optimizations for servers with a very large number of LEOs.