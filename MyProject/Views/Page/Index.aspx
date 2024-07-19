<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ContentPlaceHolderID="Meta_Title" runat="server">Nero | Photography Location</asp:Content>

<asp:Content ContentPlaceHolderID="Meta_Description" runat="server">
	<meta name="description" content="Nero Photography Location App" />
</asp:Content>

<asp:Content ContentPlaceHolderID="Head" runat="server">
	<link rel="stylesheet" type="text/css" href="/Content/css/pages/home.css" />
</asp:Content>

<asp:Content ContentPlaceHolderID="Body" runat="server">
	<%-- All Locations Hero Section --%>
	<section class="hero-section flow">
		<div class="site-wrapper padding-x padding-y">
			<h1>Nero Photography Location App</h1>
			<div class="border-container">
				<div id="map"></div>
			</div>
		</div>
	</section>

	<%-- Upload Photo Form --%>
	<section class="upload-section flow">
		<div class="site-wrapper">
			<form id="uploadForm">
				<label for="photo">Upload Photo</label>
				<input type="file" name="photo" id="photo" />

				<label for="description">Description</label>
				<input type="text" name="description" id="description" class="js-desc" />

				<label for="latitude">Latitude</label>
				<input type="text" name="latitude" id="latitude" class="js-lat" />

				<label for="longitude">Longitude</label>
				<input type="text" name="longitude" id="longitude" class="js-long" />

				<input type="button" value="Upload" class="js-submit"/>
			</form>
		</div>
	</section>

</asp:Content>

<asp:Content ContentPlaceHolderID="EOB_Javascript" runat="server">
	<script>
		(g => { var h, a, k, p = "The Google Maps JavaScript API", c = "google", l = "importLibrary", q = "__ib__", m = document, b = window; b = b[c] || (b[c] = {}); var d = b.maps || (b.maps = {}), r = new Set, e = new URLSearchParams, u = () => h || (h = new Promise(async (f, n) => { await (a = m.createElement("script")); e.set("libraries", [...r] + ""); for (k in g) e.set(k.replace(/[A-Z]/g, t => "_" + t[0].toLowerCase()), g[k]); e.set("callback", c + ".maps." + q); a.src = `https://maps.${c}apis.com/maps/api/js?` + e; d[q] = f; a.onerror = () => h = n(Error(p + " could not load.")); a.nonce = m.querySelector("script[nonce]")?.nonce || ""; m.head.append(a) })); d[l] ? console.warn(p + " only loads once. Ignoring:", g) : d[l] = (f, ...n) => r.add(f) && u().then(() => d[l](f, ...n)) })({
			key: "AIzaSyCx7I7Ph3gSBsfB77nkxY6x_eNQJuqBiIY",
			v: "weekly",
			// Use the 'v' parameter to indicate the version to use (weekly, beta, alpha, etc.).
			// Add other bootstrap parameters as needed, using camel case.
		});
	</script>
	<script>
		const latitudeInput = document.querySelector('.js-lat');
		const longitudeInput = document.querySelector('.js-long');
		const description = document.querySelector('.js-desc');
		const submit = document.querySelector('.js-submit');

		async function initMap(id, position) {
			const { Map, InfoWindow } = await google.maps.importLibrary("maps");
			const { AdvancedMarkerElement, PinElement } = await google.maps.importLibrary(
				"marker",
			);

			const map = new Map(document.getElementById("map"), {
				zoom: 12,
				center: position,
				mapId: id,
			});
			
			// Create an info window to share between markers.
			const infoWindow = new InfoWindow();

			// Create the markers.
			const pin = new PinElement({
				glyph: `${1}`,
				scale: 1.5,
			});

			const marker = new AdvancedMarkerElement({
				position,
				map,
				title: `test`,
				content: pin.element,
				gmpClickable: true,
			});

			// Add a click listener for each marker, and set up the info window.
			marker.addListener("click", ({ domEvent, latLng }) => {
				const { target } = domEvent;

				infoWindow.close();
				infoWindow.setContent(marker.title);
				infoWindow.open(marker.map, marker);
			});
		}

		function deleteMarker(marker) {
			marker.setMap(null);
		}

		function addMarker() {

		}

		function success(position) {
			const coords = {
				lat: position.coords.latitude,
				lng: position.coords.longitude
			};
			initMap(Math.random().toString(16).slice(2), coords);
			console.log(position);
		}

		function error() {
			initMap(Math.random().toString(16).slice(2), null);
		}

		const options = {
			enableHighAccuracy: true,
			maximumAge: 30000,
			timeout: 27000,
		}

		if (navigator.geolocation) {
			const watchID = navigator.geolocation.watchPosition(success, error, options);
		} else {
			console.log("Geolocation API is not available");
		}
	</script>
</asp:Content>
