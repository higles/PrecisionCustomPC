<?php
// define variables and set to empty values
$fNameErr = $lNameErr = $cNameErr = $emailErr = $phoneErr = "";
$fName = $lName = $cName = $email = $phone = $min = $max = $desc = "";
$to = "precisioncustompc@gmail.com";
$subject = "Business Contact ";
?>

<!DOCTYPE html>
<html> 
    <head>
        <link rel="stylesheet" href="http://precisioncustompc.com/css/contact.css" type="text/css" media="screen"/>
        <link rel="stylesheet" href="http://precisioncustompc.com/fonts/Exo_Condensed/stylesheet.css" type="text/css" media="screen"/>
        <style>*{padding: 0; margin: 0}</style>
        
        <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    </head>

<?php
if ($_SERVER["REQUEST_METHOD"] == "POST") {
  
    // validate first name
    if (empty($_POST["FirstName"])) {
        $fNameErr = "First Name is required.";
    }
    else {
        $fName = $_POST["FirstName"];
        // check if name only contains letters and whitespace
        if (!preg_match("/^[a-zA-Z ]*$/", $fName)) {
            $fNameErr = "Invalid first name.";
        }
    }
    
    // validate last name
    if (empty($_POST["LastName"])) {
        $lNameErr = "Last Name is required.";
    }
    else {
        $lName = $_POST["LastName"];
        // check if name only contains letters and whitespace
        if (!preg_match("/^[a-zA-Z ]*$/", $lName)) {
            $lNameErr = "Invalid last name.";
        }
    }
    
    // validate company name
    if (empty($_POST["CompanyName"])) {
        $cNameErr = "Company Name is required.";
    }
    else {
        $cName = $_POST["CompanyName"];
        // check if name only contains letters, numbers, and whitespace
        if (!preg_match("/^[a-zA-Z0-9 ]*$/", $cName)) {
            $cNameErr = "Invalid Company name.";
        }
    }
    
    // validate email
    if (empty($_POST["Email"])) {
        $emailErr = "Email is required.";
    }
    else {
        $email = $_POST["Email"];
        // check if email address is well-formed
        if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
            $emailErr = "Invalid email format";
        }
    }
    
    // validate phone number
    if (empty($_POST["Phone"])) {
        $phone = "";
    }
    else {
        $phone = $_POST["Phone"];
        $phone = preg_replace("/[^0-9]/", "", $phone);
        // check if phone number is well-formed
        if (!preg_match("/^[0-9]{10}$/", $phone)) {
            $phoneErr = "Invalid phone number";
        }
        else {
            $p = "(" . substr($phone, 0, 3) . ") ". substr($phone, 3, 3) . "-" . substr($phone, 6, 4);
            $phone = $p;
        }
    }
    
    // min price
    if (empty($_POST["MinPrice"])) {
        $min = '0';
    } else {
        $min = $_POST["MinPrice"];
    }
    
    // max price
    if (empty($_POST["MaxPrice"])) {
        $max = '0';
    } else {
        $max = $_POST["MaxPrice"];
    }
    
    // description
    if (empty($_POST["Description"])) {
        $desc = "";
    } else {
        $desc = $_POST["Description"];
    }
    
    if (empty($fNameErr) && empty($lNameErr) && empty($cNameErr) && empty($emailErr) && empty($phoneErr)) {
        // Setup Email
        $msg = '
        <html style="margin:0; padding:0;">
        <head>
        </head>
        <body style="margin:0; padding:0;">
            <div style="position:relative; display:block; padding:0em 0em; height:9em; font-family:sans-serif; background:#020;">
                <span style="position:relative; display:inline-block; width:20em; margin-left:3em;">
                    <p style="position:relative; display:block; color:#ddd; font-size:2em; line-height:0.5em;">' . $fName . ' ' . $lName . '</p>
                    <p style="position:relative; display:block; color:#ddd; font-size:1em; line-height:0.7em;">' . $phone . '</p>
                    <p style="position:relative; display:block; color:#ddd; font-size:1em; line-height:0.7em;">' . $email . '</p>
                </span>
                <span style="position:absolute; display:inline-block; color:#ddd; font-size:4em;">' . $cName . '</span>
            </div>
            <div style="position:relative; display:block; padding:1em 3em; font-family:sans-serif; background:#ddd;">
                <span style="position:relative; display:block; padding:0.3em 0; color:#020; font-size:1.5em;">Min Price: $' . $min . '.00</span>
                <span style="position:relative; display:block; padding:0.3em 0; color:#020; font-size:1.5em;">Max Price: $' . $max . '.00</span>
                <p style="position:relative; display:block; padding:1em 0; color:#020; font-size:1.2em; border-top:1px solid #020;">' . $desc . '</p>
            </div>
        </body>
        </html>
        ';

        // Always set content-type when sending HTML email
        $headers = "MIME-Version: 1.0" . "\r\n";
        $headers .= "Content-type:text/html;charset=UTF-8" . "\r\n";

        $headers .= 'From: <' . $email . ">\r\n";
        $subject .= ': ' . $cName;

        mail($to, $subject, $msg, $headers);

    }
}
?>

<form action=<?php echo htmlspecialchars($_SERVER["PHP_SELF"]); ?> method="POST" name="ContactForm">
	<input type="submit" name="Submit" value="Submit" class="submit"/>
	<p class="shorttext">First Name: <mark>*</mark></p>
	<input type="text" name="FirstName" value="<?php echo $fName;?>" required class="shorttext" />
	<p class="errortext"><?php echo $fNameErr;?></p><br/>
	<p class="shorttext">Last Name: <mark>*</mark></p>
	<input type="text" name="LastName" value="<?php echo $lName;?>" required class="shorttext"/>
	<p class="errortext"><?php echo $lNameErr;?></p><br/>
	<p class="shorttext">Company Name: <mark>*</mark></p>
	<input type="text" name="CompanyName" value="<?php echo $cName;?>" required class="shorttext"/>
	<p class="errortext"><?php echo $cNameErr;?></p><br/>
	<p class="shorttext">Email: <mark>*</mark></p>
	<input type="email" name="Email" value="<?php echo $email;?>" required class="shorttext"/>
	<p class="errortext"><?php echo $emailErr;?></p><br/>
	<p class="shorttext">Phone Number:</p>
	<input type="tel" name="Phone" value="<?php echo $phone;?>" class="shorttext phone"/>
	<p class="errortext"><?php echo $phoneErr;?></p><br/>
	<p class="shorttext">Min Price:</p>
	<input type="number" name="MinPrice" value="<?php echo $min;?>" class="shorttext price"/><br/>
	<p class="shorttext">Max Price:</p>
	<input type="number" name="MaxPrice" value="<?php echo $max;?>" class="shorttext price"/><br/>
	<p class="textbox">Tell us about your PC needs.  How many are needed and what they will be used for.</p><br/>
	<textarea name="Description" class="textbox"><?php echo $desc;?></textarea>
</form>

<script>
    $('input.price').on('change', function() {
    	$(this).val(Math.floor($(this).val()));
    });
</script>

<?php
if ($_SERVER["REQUEST_METHOD"] == "POST" && empty($fNameErr) && empty($lNameErr) && empty($cNameErr) && empty($emailErr) && empty($phoneErr)) {
?>
<script>
    $('input.submit').val("Thank You");
    $('input.submit').css({'background':'#dfd', 'color':'#000'});
    $('form').submit(false);
</script>
<?php
}
?>

            