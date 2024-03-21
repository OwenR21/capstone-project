<?php
// PHP Router

/*----------------------------------------------------------------------------------------------*/
// Setting global variables

// Starting session
session_start();

// Adding values to $_SESSION asociative array
$_SESSION['cssDir'] = __DIR__ . '/public/css/';

/*----------------------------------------------------------------------------------------------*/
// Request handling

// Setting path to views folder
$viewsDirPath = __DIR__ . '/public/views/';

// Taking incoming requests and parsing the path for the router
$request = $_SERVER['REQUEST_URI'];
$uri = str_replace("/capstone-website","",parse_url($request)['path']);

// Associative array of uri paths and associated php file destinations
$routes = [
    '' => $viewsDirPath . 'login.php',
    '/' => $viewsDirPath . 'login.php',
    '/index.php' => $viewsDirPath . 'login.php',
    '/login' => $viewsDirPath . 'login.php',
    '/dashboard' => $viewsDirPath . 'dashboard.php'
];

/*----------------------------------------------------------------------------------------------*/
// Routing users

switch (true) {

    // Successful routing
    case (array_key_exists($uri, $routes)):
        require $routes[$uri];
        break;
    // Routing error (Page does not exist)
    default:
        http_response_code(404);
        require $viewsDirPath . '404.php';
        die();
}