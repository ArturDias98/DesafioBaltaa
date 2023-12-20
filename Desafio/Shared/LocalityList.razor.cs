using AntDesign;
using AntDesign.TableModels;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Commands.Delete;
using BaltaDesafioBlazor.Domain.Contexts.LocalityContext.Queries;
using BaltaDesafioBlazor.Shared.Models.Locality;
using Microsoft.AspNetCore.Components;

namespace BaltaDesafioBlazor.Shared;

public partial class LocalityList
{
    private int _pageIndex = 1;
    private int _pageSize = 50;
    private int _totalRows;
    private string _state = string.Empty;
    private string _city = string.Empty;
    private bool _loading = true;

    private IEnumerable<LocalityModel> _localities = [];

    private async Task LoadByIdAsync(string id)
    {
        _loading = true;

        await Task.Delay(500, Token);

        var result = await QueryHandler.GetLocalityAsync(id, Token);
        if (result.Success)
        {
            _localities = [result.Result];
        }

        _loading = false;

        StateHasChanged();
    }

    private async Task LoadAsync()
    {
        _loading = true;

        await Task.Delay(500, Token);

        var result = await QueryHandler.GetLocalitiesAsync(
            _pageIndex - 1,
            _pageSize,
            _state,
            _city,
            Token);

        if (result.Success)
        {
            _localities = result.Result;
            _totalRows = result.Total;
        }

        _loading = false;

        StateHasChanged();
    }

    private Task OnChange(QueryModel<LocalityModel> queryModel)
    {
        return LoadAsync();
    }

    private Task OnSearchState(string state)
    {
        _state = state;
        _pageIndex = 1;
        return LoadAsync();
    }

    private Task OnSearchCity(string city)
    {
        _city = city;
        _pageIndex = 1;
        return LoadAsync();
    }

    private Task OnSearchCode(string id)
    {
        _state = string.Empty;
        _city = string.Empty;
        _pageIndex = 1;

        return LoadByIdAsync(id);
    }

    private async Task OnDelete(LocalityModel locality)
    {
        var command = new DeleteLocalityCommand(locality.Id);
        var result = await LocalityHandler.ExecuteAsync(command, Token);

        if (result.Success)
        {
            await Task.WhenAll(
                MessageService.Success("Localidade excluída com sucesso"),
                LoadAsync())
                .ConfigureAwait(false);
        }
    }

    [Inject] ILocalityQueryHandler QueryHandler { get; set; } = null!;
    [Inject] LocalityHandler LocalityHandler { get; set; } = null!;
    [Inject] IMessageService MessageService { get; set; } = null!;

    [CascadingParameter] CancellationToken Token { get; set; }
}
