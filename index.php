<?php
// PHP Router

/*----------------------------------------------------------------------------------------------*/
// Setting global variables

// Starting session
session_start();

/*----------------------------------------------------------------------------------------------*/
// Request handling

// Setting path to views folder
$viewsDirPath = __DIR__ . '/public/views/';

// Taking incoming requests and parsing the path for the router
$request = $_SERVER['REQUEST_URI'];
$uri = parse_url($request)['path'];

// Associative array of uri paths and associated php file destinations
$routes = [
    // Set routes to homepage
    '' => $viewsDirPath . 'home.php',
    '/' => $viewsDirPath . 'home.php',
    '/index.php' => $viewsDirPath . 'home.php',
    '/home' => $viewsDirPath . 'home.php',
    
    // Set routes to services pages
    '/oil-change' => $viewsDirPath . 'services/oil-change.php', 
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
    // Route user to correct page
    case (array_key_exists($uri, $routes)):
        require $routes[$uri];
        break;
    
    // Else route user to error 404 page
    default:
        http_response_code(404);
        require 'public/views/404.php';
        die();
}
