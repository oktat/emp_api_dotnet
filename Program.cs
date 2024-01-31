var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();
var db = new DataService();



app.UseSwagger();

app.MapGet("/employees", () => {
    var emps = db.Employees.ToList();
    return emps;
});

app.MapPost("/employees", (Employee emp) => {
    db.Employees.Add(emp);
    db.SaveChanges();
    return Results.Created(@"/employeeitems/{emp.Id}", emp);
});

app.MapPut("/employees/{id}", (int id, Employee inputEmp) => {
    var emp = db.Employees.Find(id);
    if (emp is null ) return Results.NotFound();
    emp.Name = inputEmp.Name;
    emp.City = inputEmp.City;
    emp.Salary = inputEmp.Salary;
    db.SaveChanges();
    return Results.NoContent();
});

app.MapDelete("/employees/{id}", (int id) => {
    if(db.Employees.Find(id) is Employee emp) {
        db.Employees.Remove(emp);
        db.SaveChanges();
        return Results.NoContent();
    }
    return Results.NoContent();
});

app.UseSwaggerUI();
app.Run();
