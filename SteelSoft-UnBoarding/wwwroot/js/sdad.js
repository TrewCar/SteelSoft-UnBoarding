$.ajax({
	url: "http://109.168.144.30/Film/Get/Random",
	dataType: "JSON",
	type: "GET"
})
.done(function(json){
	console.log(json);
})