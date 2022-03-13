﻿
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MinecraftLibrary.API.Types.Chat;

public class HexColorConverter : JsonConverter<HexColor>
{
    public override HexColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => new HexColor(reader.GetString());

    public override void Write(Utf8JsonWriter writer, HexColor value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString() ?? string.Empty);
}
