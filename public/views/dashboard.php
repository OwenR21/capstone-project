<!DOCTYPE html>
<?php
// It is necessary to comment out the lines below this comment through line 12 if a database is not set up
/* comment multiple lines at once with this type of comment */

use function PHPSTORM_META\type;

//Todo: The code here should work if the .env file is set up right, but if it isn't it would be good to log that to the console
// try {
//     $hostname = $_ENV['hostname'];
//     $username = $_ENV['username'];
//     $password = $_ENV['password'];
//     $db = $_ENV['db'];

//     $conn = mysqli_connect($hostname,$username,$password,$db);
//     $query = "SELECT Link FROM Data Where UserID = '1'";
//     $result = mysqli_query($conn, $query);
//     $row = mysqli_fetch_assoc($result);
// }
// catch(Error $e) {
//     echo "<script> console.log(" . json_encode($e, JSON_HEX_TAG) . ") </script>";
// }

//$row = "../pictures/sampletest.jpg";
echo "Invoice 1's Filepath is being pulled from database: " . "<br>";
?>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dashboard</title>
    <link rel="stylesheet" href="../css/dashboard-style.css">
    <style>
        body {
            font-family: 'Arial', sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f0f2f5;
        }
        .container {
            max-width: 800px;
            margin: auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        h1 {
            color: #333;
        }
        p, label {
            color: #666;
        }
        .invoice-display {
            border: 1px solid #ccc;
            margin-top: 20px;
            padding: 10px;
        }
        iframe {
            width: 100%;
            height: 500px;
            border: none;
        }
    </style>
</head>
<body>
    <div class="container">
        <h1>Welcome to your Dashboard!</h1>
        <p>Select an invoice to view:</p>

        <label for="invoiceSelect">Invoice:</label>
        <select id="invoiceSelect" onchange="showInvoice(this.value)">
            <option value="">Select an Invoice</option>
            <option value="<?php echo $row["Link"]; ?>">Invoice 1</option>
            <option value="../pictures/sample-invoice-2.jpg">Invoice 2</option>
            
        </select>

        <div class="invoice-display" id="invoiceDisplay">
            <!-- invoice will be displayed here -->
        </div>
    </div>

    <script>
        function showInvoice(filename) {
            var displayArea = document.getElementById('invoiceDisplay');
            if(filename) {
                displayArea.innerHTML = '<iframe src="' + filename + '"></iframe>';
            } else {
                displayArea.innerHTML = 'No invoice selected.';
            }
        }
    </script>
</body>
</html>

<!-- //echo $_POST['name']; -->
