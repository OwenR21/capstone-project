<?php
// PHP Router

/*----------------------------------------------------------------------------------------------*/
// Setting global variables

// Starting session
session_start();

// Adding values to $_SESSION associative array
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
    '' => $viewsDirPath . 'home.php', // Set as new homepage
    '/' => $viewsDirPath . 'home.php', // Set as new homepage
    '/index.php' => $viewsDirPath . 'home.php', // Explicitly set homepage
    //'/invoice' => $viewsDirPath . 'invoice.php',//
    //'/login' => $viewsDirPath . 'login.php', // Dedicated login route
    //'/dashboard' => $viewsDirPath . 'dashboard.php', // Dashboard access
    '/oil-change' => $viewsDirPath . 'services/oil-change.php', // Oil Change service page
    '/brake-services' => $viewsDirPath . 'services/brake-services.php',
    '/wheel-alignment' => $viewsDirPath . 'services/wheel-alignment.php',
    '/battery-replacement' => $viewsDirPath . 'services/battery-replacement.php',
    '/radiator-flush' => $viewsDirPath . 'services/radiator-flush.php',
    '/air-conditioning-service' => $viewsDirPath . 'services/air-conditioning-service.php',
    '/transmission-service' => $viewsDirPath . 'services/transmission-service.php',
    '/tire-service' => $viewsDirPath . 'services/tire-service.php',
    '/diagnostic-service' => $viewsDirPath . 'services/diagnostic-service.php',
    '/headlights-replacement' => $viewsDirPath . 'services/headlights-replacement.php',
];

/*----------------------------------------------------------------------------------------------*/
// Routing users

switch (true) {
    case (array_key_exists($uri, $routes)):
        require $routes[$uri];
        break;
    default:
        http_response_code(404);
        require $viewsDirPath . '404.php';
        die();
}

