using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace GMapWinForm
{
    internal class AppViewModel
    {
        private GMapControl mapControl;
        private GMapOverlay markerOverlay;
        private string connectionString;
        public GMapMarker CurrentMarker { get; set; }
        public GMapControl MapControl { get => mapControl; }


        public AppViewModel(GMapControl mapControl)
        {
            this.mapControl = mapControl;

            markerOverlay = new GMapOverlay("Markers");
            mapControl.Overlays.Add(markerOverlay);
        }

        public void SetConnectionString(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InitializeMapControl(GMapProvider provider)
        {
            // Настройка карты

            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            mapControl.MapProvider = provider;
            mapControl.MinZoom = 2;
            mapControl.MaxZoom = 16;
            mapControl.Zoom = 12;
            mapControl.Position = new PointLatLng(53.347001, 83.7135691);
            mapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;
            mapControl.CanDragMap = true;
            mapControl.DragButton = MouseButtons.Left;
            mapControl.ShowCenter = false;
            mapControl.ShowTileGridLines = false;
        }

        public void LoadCoordinates()
        {
            // Запрос на выборку данных
            string query = "SELECT * FROM Markers";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand command = new SqlCommand(query, con);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["ID"]);
                        double lat = Convert.ToDouble(reader["Latitude"]);
                        double lng = Convert.ToDouble(reader["Longitude"]);

                        GMapMarker marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.blue_dot);
                        marker.ToolTipText = id.ToString();
                        marker.Tag = id;
                        markerOverlay.Markers.Add(marker);
                    }
                }
            }
        }

        public void MarkerOverlayDrag()
        {
            CurrentMarker = mapControl.Overlays
                    .SelectMany(o => o.Markers)
                    .FirstOrDefault(m => m.IsMouseOver);
        }

        public void MarkerNewPostition(int x, int y) => CurrentMarker.Position = mapControl.FromLocalToLatLng(x, y);


        public void UpdateMarker()
        {
            string query = "UPDATE Markers SET Latitude = @lat, Longitude = @lng WHERE Id = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@lat", CurrentMarker.Position.Lat);
                command.Parameters.AddWithValue("@lng", CurrentMarker.Position.Lng);
                command.Parameters.AddWithValue("@id", CurrentMarker.Tag);

                connection.Open();
                command.ExecuteNonQuery();
            }
            CurrentMarker = null;
        }
    }
}
