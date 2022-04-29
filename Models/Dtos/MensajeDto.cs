namespace SysSara.Models.Dtos;

public class MensajeDto
{
    public MensajeDto() { }

    public MensajeDto(bool mensaje, string titulo, string texto, string icono)
    {        
        Mensaje = mensaje;
        Titulo = titulo;
        Texto = texto;
        Icono = icono;
    }

    public bool Mensaje { get; set; } = false;
    public string? Titulo { get; set; }
    public string? Texto { get; set; }
    public string? Icono { get; set; }    
}

public static class IconError
{
    public const string Error = "error";
    public const string Warning = "warning";
    public const string Info = "info";
    public const string Question = "question";
    public const string NoSession = "nosession";
    public const string Success = "success";
}