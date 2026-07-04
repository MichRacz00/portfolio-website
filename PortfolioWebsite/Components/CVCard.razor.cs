<div class="cv-card">

    @if (!string.IsNullOrEmpty(Title))
{
    <h3>@Title</h3>
}

@if (!string.IsNullOrEmpty(SubTitle))
{
    <h4>@SubTitle</h4>
}

@if (!string.IsNullOrEmpty(Location))
{
    <div>@Location</div>
}

@if (!string.IsNullOrEmpty(Period))
{
    <div class="cv-period">@Period</div>
}

@if (BulletPoints?.Any() == true)
{
    <ul class="cv-content">
        @foreach (var item in BulletPoints)
    {
        <li>@item</li>
    }
    </ul>
}

</div>

    @code {
    [Parameter] public string? Title { get; set; }
[Parameter] public string? SubTitle { get; set; }
[Parameter] public string? Location { get; set; }
[Parameter] public string? Period { get; set; }

[Parameter] public List<string> BulletPoints { get; set; } = new();
}