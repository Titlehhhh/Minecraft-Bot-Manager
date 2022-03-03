﻿namespace MinecraftLibrary.API.World
{
    public interface IBlockPallete
    {
        Material FromId(int id);
        bool IdHasMeta { get; }
    }
}
