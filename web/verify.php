<?php 
	define('USE_DATABASE',1);
	include 'databank.php';
	$secret = "I'm all about open source, but i can't share this with you.";
	if (!empty($_SERVER['HTTP_CLIENT_IP'])) {
		$ip = $_SERVER['HTTP_CLIENT_IP'];
	} elseif (!empty($_SERVER['HTTP_X_FORWARDED_FOR'])) {
		$ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
	} else {
		$ip = $_SERVER['REMOTE_ADDR'];
	}
	if (isset($_GET['actid'])) {
			$actid =  mysqli_real_escape_string($DB_OBJ, $_GET['actid']);
	} else {
			$actid = "!!NONE3!!";
	}

	if (isset($_POST['g-recaptcha-response'])) {
		 $resp = $_POST['g-recaptcha-response'];
	} else {
		header('Location: ./index.php' . "?success=0&reason=No%20captcha%20token%20received&actid=$actid");
		die("no response from captcha $ip");
	}
	
	//echo ("actid $actid");
	//echo ("gcap $resp");
	
	
// extract data from the post
// set POST variables

$data = array(
            'secret' => "$secret",
            'response' => "$resp"
        );

$verify = curl_init();
curl_setopt($verify, CURLOPT_URL, "https://www.google.com/recaptcha/api/siteverify");
curl_setopt($verify, CURLOPT_POST, true);
curl_setopt($verify, CURLOPT_POSTFIELDS, http_build_query($data));
curl_setopt($verify, CURLOPT_SSL_VERIFYPEER, false);
curl_setopt($verify, CURLOPT_RETURNTRANSFER, true);
$response = curl_exec($verify);

$resp_dec = json_decode((string)$response);
if ($resp_dec->success==false) {
	header('Location: ./index.php' . "?success=0&reason=Recaptcha validation failed&actid=$actid");
} else {
	
	
				
			
				
	
			$rpquery = "UPDATE xen_activations SET activated=1 WHERE activation_id='$actid'";
			$res = $DB_OBJ->query($rpquery);
			
			if ($res==false) {
						echo($DB_OBJ->error);
						die();
					header('Location: ./index.php' . "?success=0&reason=Database error. &actid=$actid");
			
			}
				
	
	
	header('Location: ./index.php' . "?success=1&reason=Successfully verified that you're human :)&actid=$actid");
}


?>

 