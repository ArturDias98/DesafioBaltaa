using AntDesign;
using System.Text;

namespace BaltaDesafioBlazor.Services;

internal class PopUpErrorsService(IConfirmService confirmService)
{
    public async Task ShowErrors(IReadOnlyCollection<string> errors, string title)
    {
        /*var builder = new StringBuilder()
            .Append("<ul>");

        foreach (var error in errors)
        {
            builder
                .Append("<li>")
                .Append(error)
                .Append("</li>");
        }

        builder.Append("</ul>");*/

        var builder = new StringBuilder();

        foreach (var error in errors)
        {
            builder.AppendLine(error);
        }
        await confirmService.Show(
            builder.ToString(),
            title,
            ConfirmButtons.OK,
            ConfirmIcon.Error);
    }
}
