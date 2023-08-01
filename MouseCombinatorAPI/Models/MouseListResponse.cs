//this class represents a base instance of a Mouse List object-- simply, a list of key:value pairs enumerating the available mice in the database
//key:value format-> id : name
public class MouseListResponse {
    public Dictionary<String, int>? id {get; set;}
}