<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login Page</title>
    <link rel="stylesheet" href="public/css/login.css">
</head>
<body>
    <div class="bg-image"></div> 
    <div class="login-container">
        <form class="login-form" action="index.php" method="post">
            <h2>Login</h2>
            <div class="input-group">
                <label for="username">Username</label>
                <input type="text" id="username" name="username" required>
            </div>
            <div class="input-group">
                <label for="password">Password</label>
                <input type="password" id="password" name="password" required>
            </div>
            <button type="button" onclick="login()">Login</button>
            <p id="loginError" style="color: red; display: none;">Invalid username or password</p>
        </form>
    </div>
</body>

    <script>
        function login() {
            var username = document.getElementById('username').value;
            var password = document.getElementById('password').value;
            
            // Basic check for username and password
            if(username === 'admin' && password === 'password') {
                // alert('Login Successful'); shows  login successful messafe
                window.location.href = '/capstone-website/dashboard';
            } else {
                // Show error message
                document.getElementById('loginError').style.display = 'block';
            }
        }
    </script>
    
</html>
