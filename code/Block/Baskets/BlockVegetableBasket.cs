﻿using System.Linq;

namespace FoodShelves;

public class BlockVegetableBasket : BaseFSBasket {
    public static RestrictionData VegetableBasketData { get; set; } = new();

    public override float[,] GetTransformationMatrix(string path) {
        float[] x = { .75f }, y = { 0 }, z = { -.03f }, rX = { -2 }, rY = { 4 }, rZ = { 1 };
        if (path == null) return GenTransformationMatrix(x, y, z, rX, rY, rZ);

        foreach (var group in VegetableBasketData.GroupingCodes) {
            if (group.Value.Contains(path)) {
                switch(group.Key) {
                    case "group1":
                        x = new float[] { .75f,  .3f,  .3f, .3f, .65f, .35f,  .5f, .1f,  .6f, .58f, .2f, .25f };
                        y = new float[] { .01f, .01f, .01f, .25f,   0, .35f,  .2f, .2f,  .4f,  .4f, .5f, .52f };
                        z = new float[] { .05f,    0,  .4f, .1f, .45f, .35f, .18f, .1f, .02f,  .4f,  0f, .15f };

                        rX = new float[] {  -2,    0,    0,  -3,   -3,   28,   16,  30,    0,    5,  -8,    8 };
                        rY = new float[] {   4,   -2,   15,  -4,   10,   12,   30,   4,   -5,   -2,  20,   15 };
                        rZ = new float[] {   1,   -1,    0,  45,    1,   41,    5,  17,   -2,  -20,  16,    8 };
                        return GenTransformationMatrix(x, y, z, rX, rY, rZ);
                    case "group2":
                        x = new float[] { .75f, .3f, .19f,  .3f, .51f, .35f,  .05f,  .85f,   .7f,  .9f, .58f,   .4f };
                        y = new float[] {    0,   0,    0, .25f,    0, .35f,   .2f, -.25f, -.35f, .15f,  .4f, -.35f };
                        z = new float[] { .05f,   0,  .3f, .05f,  .4f, .25f, -.05f,  .05f,  .05f, .35f,  .3f,  -.3f };

                        rX = new float[] {  -2,   0,    0,   -3,   -3,   28,    16,    90,    90,   30,    5,    90 };
                        rY = new float[] {   4,  -2,   15,   -4,   10,   12,    30,     0,     0,    4,   -2,     0 };
                        rZ = new float[] {   1,  -1,    0,   45,    1,   41,     5,    12,    83,   17,  -20,    83 };
                        return GenTransformationMatrix(x, y, z, rX, rY, rZ);
                    case "group3":
                        x = new float[] { .75f, .74f,  .73f, .72f,  .71f, .70f, .15f, .15f, .15f, .15f, .15f, .15f, .75f, .74f, .73f, .72f, .71f, .70f, .15f, .15f, .15f, .15f, .15f, .15f, .75f, .74f, .73f, .72f, .71f, .70f, .15f, .15f, .15f, .15f, .15f, .15f };
                        y = new float[] {    0,    0,     0,    0,     0,    0,    0,    0,    0,    0,    0,    0, .15f, .15f, .15f, .15f, .15f, .15f, .15f, .15f, .15f, .15f, .15f, .15f, .30f, .30f, .30f, .30f, .30f, .30f, .30f, .30f, .30f, .30f, .30f, .30f };
                        z = new float[] {-.03f, .12f,  .27f, .42f,  .57f, .72f,-.03f, .12f, .27f, .42f, .57f, .72f,-.03f, .12f, .27f, .42f, .57f, .72f,-.03f, .12f, .27f, .42f, .57f, .72f,-.03f, .12f, .27f, .42f, .57f, .72f,-.03f, .12f, .27f, .42f, .57f, .72f };

                        rX = new float[] {  -2,   -2,    -2,   -2,    -2,   -2,    0,    0,    0,    0,    0,    0,   -2,   -2,   -2,   -2,   -2,   -2,    0,    0,    0,    0,    0,    0,   -2,   -2,   -2,   -2,   -2,   -2,    0,    0,    0,    0,    0,    0 };
                        rY = new float[] {   4,    4,     4,    4,     4,    4,   -2,   -2,   -2,   -2,   -2,   -2,    4,    4,    4,    4,    4,    4,   -2,   -2,   -2,   -2,   -2,   -2,    4,    4,    4,    4,    4,    4,   -2,   -2,   -2,   -2,   -2,   -2 };
                        rZ = new float[] {   1,    1,     1,    1,     1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1,    1 };
                        return GenTransformationMatrix(x, y, z, rX, rY, rZ);
                }
            }
        }

        return GenTransformationMatrix(x, y, z, rX, rY, rZ);
    }

    protected override MeshData GenBasketContents(ItemStack itemstack, ITextureAtlasAPI targetAtlas) {
        ItemStack[] contents = GetContents(api.World, itemstack);

        string itemPath = "";
        if (contents != null && contents.Length > 0 && contents[0] != null) {
            itemPath = contents[0].Collectible.Code;
        }

        MeshData contentMesh = GenContentMesh(api as ICoreClientAPI, targetAtlas, contents, GetTransformationMatrix(itemPath), 0.5f, Transformations);

        return contentMesh;
    }
}
