<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>PDF Listing</title>
    <link rel="stylesheet" href="public/css/invoice.css">
</head>


<?php include 'partials/header.php'; ?>

<div style="height: 2px; background-color: #ccc; margin: 20px 0;"></div>

<body>
    <h1>Available PDFs</h1>
    <div class="pdf-list">
        <?php
            $directory = 'public/pictures'; // Change this path to your PDFs directory
            $files = scandir($directory);

            foreach ($files as $file) {
                if (strpos($file, '.pdf') !== false) {
                    echo '<div class="pdf-item"><a href="' . $directory . '/' . $file . '">' . $file . '</a></div>';
                }
            }
        ?>
    </div>
</body>
</html>
