<?php

$mysqli = new mysqli("mysql.eecs.ku.edu", "c803b216", "si3ik4eV", "c803b216");

/* check connection */
if ($mysqli->connect_error) {
    die("Connection failed: " . $mysqli->connect_error);
    printf("Connect failed: %s\n", $mysqli->connect_error);
    exit();
}

$username = $_POST["new_user"];

$query = "INSERT INTO BlockUsers (username) VALUES ('$username');";

  if ($result = $mysqli->query($query)) {
    $result->free();
  }
  else{
    echo "<p>Error: " . $mysqli . "<br>" . $mysqli->error;
  }

/* close connection */
$mysqli->close();
?>
