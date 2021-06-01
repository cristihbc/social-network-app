# social-network-app

<h2>The app's architecture</h2>
<img src="https://raw.githubusercontent.com/alexcogojocaru/social-network-app/master/res/app-architecture.png" alt="api-architecture">

<h2>Classes UML Diagram</h2>
<img src="https://raw.githubusercontent.com/alexcogojocaru/social-network-app/master/res/socialapp-classes.png" alt="api-architecture">

<h2>The app's workflow</h2>
<img src="https://raw.githubusercontent.com/alexcogojocaru/social-network-app/master/res/socialapp-flow.png" alt="api-architecture">


## Building the application with Docker

```
git clone https://github.com/alexcogojocaru/social-network-app.git 
cd social-network-app
docker build -t socialapp .
docker run -p 5001:5001 -e PORT=5001 -d socialapp 
```