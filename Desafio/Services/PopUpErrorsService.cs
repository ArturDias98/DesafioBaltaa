using AntDesign;
using System.Text;

namespace BaltaDesafioBlazor.Services;

internal class PopUpErrorsService(IConfirmService confirmService)
{
    public async Task ShowErrors(IReadOnlyCollection<string> errors)
    {
        var builder = new StringBuilder()
            .Append("<ul>");

        foreach (var error in errors)
        {
            builder
                .Append("<li>")
                .Append(error)
                .Append("</li>");
        }

        builder.Append("</ul>");

        await confirmService.Show(builder.ToString(), "Erros", ConfirmButtons.OK);
    }
}
