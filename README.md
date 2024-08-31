<!-- PROJECT LOGO -->
<h2 align="center">FLUXTALK</h2>
  <p align="center">
    Windows Application dedicated to holding no message data while chatting!
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project
Welcome to the Chat Application project! This application is designed to provide a simple, 
secure, and efficient way to communicate with others without holding any message logs. The primary focus is
on real-time messaging, with features that prioritize user privacy and seamless updates. The application
is under development actively.
<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started
### Prerequisites

Before you begin, ensure you have the following installed on your system:
- Visual Studio 2019 or later with the following workloads:
     - .NET Desktop Development
- .NET Core SDK or .NET Framework
- Git
### Installation

1. Clone the repo
Open your terminal and navigate to the directory where you want to clone the project.
- Then paste the following command:
   ```sh
   git clone https://github.com/Oguzoz1/ChatApp
   ```
2. Restore NuGet Packages
   
The project includes necessary dependencies like Newtonsoft.Json via NuGet packages. Visual Studio typically restores these packages automatically when you open the solution. If it doesn't, follow these steps:
  1. Restore Packages Automatically
      - Upon openning the solution, Visual Studio should prompt you to restore missing NuGet packages. Click 'Restore' if prompted.
    
        
  2. Restore Packages Manually:
      - Using Solution Explorer:
          - Right-Click on the Solution in the 'Solution Explorer'.
          - Select 'Restore NuGet Packages'.
      - Using Package Manager Console:
          - Go TO 'Tools' > 'NuGet Package Manager' > 'Package Manager Console'.
          - In the console, run:        
               ```sh
               Update-Package -reinstall
               ```
          - Using .NET CLI:
            - Open Terminal and Run:    
             ```sh
             nuget restore
             ```

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- ROADMAP -->
## Milestones

- [ ] Add Client Auto-Update System
- [ ] Add User Authentication
- [ ] Add Private Messaging Feature
- [ ] Add Image Support for Chatting
- [ ] Add User Profile Picture
- [ ] Add Encryption to messages

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- LICENSE -->
## License

 See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- CONTACT -->
## Contact

Oğuz Özüer

Project Link: https://github.com/Oguzoz1/FluxTalk

Linked-in: https://www.linkedin.com/in/mehmetoguzozuer/

<p align="right">(<a href="#readme-top">back to top</a>)</p>


