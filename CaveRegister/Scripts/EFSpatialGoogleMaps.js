(function () {
    // Method signature matching $.fn.each()'s, for easy use in the .each loop later.
    var initialize = function (i, el) {
        // el is the input element that we need to initialize a map for, jQuery-ize it,
        //  and cache that since we'll be using it a few times.
    	var $input = $(el);
    	var $latInput = $input.find('input.latitude');
    	var $longInput = $input.find('input.longitude');
    	var $latlongInput = $input.find('input.latlong');
        var siberia = new google.maps.LatLng(60, 105);
        var gauteng = new google.maps.LatLng(60, 105);
        // Create the map div and insert it into the page.
        var $map = $('<div>', {
            css: {
                width: '400px',
                height: '400px'
            }
        }).insertAfter($input);

        var latLong = { //default position
        	latitude: 40.716948,
        	longitude: -74.003563
        };

    	// Initialize the map widget.
        var map = new google.maps.Map($map[0], {
        	zoom: 17,
        	//center: position,
        	mapTypeId: google.maps.MapTypeId.HYBRID
        });

    	// Create a "Google(r)(tm)" LatLong object representing our DBGeometry's lat/long.
        var position = new google.maps.LatLng(latLong.latitude, latLong.longitude);


    	// Place a marker on it, representing the DBGeometry object's position.
        var marker = new google.maps.Marker({
        	position: position,
        	map: map
        });

    	

        debugger;
        // Attempt to parse the lat/long coordinates out of this input element.
        latLong = parseLatLong($latlongInput.val());

        // If there was a problem attaining a lat/long from the input element's value,
        //  set it to a sensible default that isn't in the middle of the ocean.
        if (!latLong || !latLong.latitude || !latLong.longitude) {
            if (navigator.geolocation) {
            	browserSupportFlag = true;
            	navigator.geolocation.getCurrentPosition(function (pozzy) {
            		position = new google.maps.LatLng(pozzy.coords.latitude, pozzy.coords.longitude);
            		map.setCenter(position);
            		marker.setPosition(position);
            	}, function () {
            		handleNoGeolocation(browserSupportFlag);
            	});
            }
            	// Browser doesn't support Geolocation
            else {
            	browserSupportFlag = false;
            	handleNoGeolocation(browserSupportFlag);
            }
        }
        else
        {
        	position = new google.maps.LatLng(latLong.latitude, latLong.longitude);
        	map.setCenter(position);
        	marker.setPosition(position);
        }

        
        function handleNoGeolocation(errorFlag) {
        	var initialLocation;
        	if (errorFlag == true) {
        		alert("Geolocation service failed.");
        		initialLocation = gauteng;
        	} else {
        		alert("Your browser doesn't support geolocation. We've placed you in Siberia.");
        		initialLocation = siberia;
        	}
        	map.setCenter(initialLocation);
        }



        

        var updateMarker = function (updateEvent) {
            marker.setPosition(updateEvent.latLng);
            debugger;
            // This new location might be outside the current viewport, especially
            //  if it was manually entered. Pan to center on the new marker location.
            map.panTo(updateEvent.latLng);
            // Black magic, courtesy of Hanselman's original version.
        	$latlongInput.val(marker.getPosition().toUrlValue(13));
            $latInput.val(updateEvent.latLng.A);
            $longInput.val(updateEvent.latLng.F);
        };

        // If the input came from an EditorFor, initialize editing-related events.
        if ($input.hasClass('editor-for-dbgeography')) {
            google.maps.event.addListener(map, 'click', updateMarker);

            // Attempt to react to user edits in the input field.
			$latInput.on('change', updateFromInput);
			$longInput.on('change', updateFromInput);
        }

        function updateFromInput()
        {
        	//var latLong = parseLatLong(this.value);

        	latLong = new google.maps.LatLng($latInput.val(), $longInput.val());

        	updateMarker({ latLng: latLong });
        }
    };

    var parseLatLong = function (value) {
        if (!value) { return undefined; }

        var latLong = value.match(/-?\d+\.\d+/g);

        return {
            latitude: latLong[0],
            longitude: latLong[1]
        };
    };

    // Find all DBGeography inputs and initialize maps for them.
    $('.editor-for-dbgeography, .display-for-dbgeography').each(initialize);
})();
