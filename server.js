// Initializing Packages
const express = require('express');
const app = express();
const mariadb = require('mariadb');

// Initializing port
const port = 3000;

// Server is listening on port
app.listen(port, () => {
    console.log(`Example app listening on port ${port}`)
});

/*-----------------------------------------------------------------------------*/
// Routing

// Login page
app.get('/', (req,res) => {
    res.sendFile(__dirname + '/login.html')
});                                             // We may want something like bcrypt here to handle logging in unless you have that logic somewhere already

// Dashboard
app.get('/', (req,res) => {
    res.sendFile(__dirname + '/dashboard.html')
})

/*-----------------------------------------------------------------------------*/
// Connecting to mariadb

// Resources:
// https://mariadb.com/kb/en/nodejs-connector/
// I found the .../node-js-connection-options/ page to be helpful for the info below

const pool = mariadb.createPool({           
    host: 'hostname',                       
    user: 'username',
    password: 'password',
    database: 'database',
    socketPath: '/var/run/mariadb10.sock',       // this is what we saw on QNAP earlier
    port: 3307//,                                // and this is the port number we saw next to it
    //socketTimeout: int time in milliseconds after connection established , // times out the socket connection
    //rowsAsArray: true , // allows information returned from the db to be an array instead of JSON
    //connectionLimit: 5 // this is just what the resource i'm looking at had       looks like limit is set to 10 by default
})

pool.getConnection().then(conn => {
    //make queries like this example:
    conn.query("select * from table1").catch( err => {
        console.log(err);
    })
})

/*-----------------------------------------------------------------------------*/
// Helpful info

/*---------------------------------------*/
// Running the server

// in the command line type 'npm run start'
// it runs the script in package.json called 'start'
// the script just runs in the terminal 'node server.js', but we could expand it to do other things as well (idk what but this seems standard)

/*---------------------------------------*/
// parsing JSON (normally what a db returns)

/*
const json = '{"result":true, "count":42}';
const obj = JSON.parse(json);
console.log(json)
console.log(obj)
*/
