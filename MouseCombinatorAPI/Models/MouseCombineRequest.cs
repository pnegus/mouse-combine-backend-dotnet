//this class models an expected request body for combining two or more mice
using Microsoft.AspNetCore.Mvc;
public class MouseCombineRequest {
    [FromBody]
    public List<int> mouse_ids_to_combine {get; set;}
}