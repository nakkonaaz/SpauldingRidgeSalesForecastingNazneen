# Sales Forecasting Application

## Overview
The Sales Forecasting Application is designed to provide accurate sales forecasting using historical sales data. The application includes features to visualize both aggregated sales and sales breakdown by state, apply percentage increments for forecasting, and download the forecasted data in CSV format. This project is built using ASP.NET Core MVC and SQL Server.

## Features
- Query sales data for a specific year.
- Display total sales and a breakdown by state.
- Apply a percentage increment to simulate future sales growth.
- Download forecasted sales data as a CSV file.
- Visualize aggregated sales and sales breakdown by state using charts.

## Technologies Used
- C#
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server
- Chart.js
- Bootstrap

## Installation and Setup
### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio](https://visualstudio.microsoft.com/) or any other preferred IDE
- [Node.js](https://nodejs.org/) (for package management)

### Steps
1. **Clone the repository:**
    ```sh
    git clone https://github.com/your-repository/sales-forecasting-app.git
    cd sales-forecasting-app
    ```

2. **Set up the database:**
    - Import the provided dataset into SQL Server.
    - Update the connection string in `appsettings.json` to match your SQL Server configuration.

3. **Install dependencies:**
    ```sh
    dotnet restore
    npm install
    ```

4. **Run the application:**
    ```sh
    dotnet run
    ```

5. **Access the application:**
    Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000`.

## Project Structure
- `Controllers/`: Contains the MVC controllers.
- `Models/`: Contains the data models.
- `Views/`: Contains the Razor views.
- `wwwroot/`: Contains static files such as CSS, JavaScript, and images.
- `Contexts/`: Contains the DbContext for Entity Framework Core.
- `ViewModels/`: Contains the view models used for data transfer between controllers and views.

## Usage
1. **Query Sales Data:**
    - Navigate to the Sales page.
    - Enter a specific year to query sales data.
    - View the total sales and breakdown by state.

2. **Apply Percentage Increment:**
    - Enter a percentage to simulate sales growth.
    - View the incremented sales values.

3. **Download CSV:**
    - Click the "Download CSV" button to download the forecasted sales data.

4. **Visualize Data:**
    - View the aggregated sales chart and the breakdown by state chart.

## Example Screenshots
![Home Page](screenshots/home.png)
![Sales Page](screenshots/sales-1.png)
(screenshots/sales-2.png)
(screenshots/sales-3.png)
![Charts](screenshots/total-sales-graph.png)
(screenshots/breakdown-graph.png)

## Future Improvements
- Add authentication and authorization.
- Implement more advanced forecasting algorithms.
- Enhance the UI with more detailed analytics and visualizations.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing
1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes and commit them (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Open a Pull Request.

## Contact
For any inquiries or issues, please contact [Your Name](mailto:your-email@example.com).

