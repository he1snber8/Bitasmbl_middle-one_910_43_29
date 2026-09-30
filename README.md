# Quickstart for Bitasmbl project (.NET)

## 1) Install Bitasmbl-CLI package

```bash
npm i bitasmbl-cli
```

## 2) Run bitasmbl command to set up the project

```bash
bitasmbl pull --repoUrl https://github.com/he1snber8/Bitasmbl_middle-one_910_43_29 --appId 43 --repoId 29
```

## 3) Enter into the main directory and start coding!

```bash
cd Bitasmbl_middle-one_910_43_29
```

## Customize requirements in a way you like

Bitasmbl organizes development into requirements. Each requirement describes a feature or implementation goal and can define suggested file locations through a `paths` array.

The `paths` property acts as a mapping guideline, helping contributors understand where related code should live.

You can customize `paths` mappings through the `bitasmbl.json` file.

{"Requirement":"Define task entity","Paths":["**/Models/**","**/Entities/**","**/Domain/**"]}

## Requirement Evaluation

Bitasmbl includes a requirement evaluation workflow that lets contributors select a task and submit work for validation.

Run:

```bash
bitasmbl evaluate
```

Example output:

<pre>
? Available Requirements:

❯ [<span style="color:#9333ea">1</span>] <span style="color:#9333ea"> Define portfolio layout </span>            [3]
  [2] Build showcase components            [3]
  [3] Implement navigation routing         [3]
</pre>

`[x]` on the right represents the number of submission attempts remaining for a requirement.

## Example evaluation result

```csharp
/*
|--------------------------------------------------------------------------
| BITASMBL EVALUATION
|--------------------------------------------------------------------------
| REQUIREMENT:
| Implement product catalog API
|
| SCORE: 12/100
| STATUS: FAIL ✕
|
| INSIGHT:
| The endpoint returns static product data and does not use a repository,
| service layer, filtering, or async database access.
|--------------------------------------------------------------------------
*/

using Microsoft.AspNetCore.Mvc;

namespace BitasmblProject.Features.Catalog;

[ApiController]
[Route("api/products")]
public sealed class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = new[]
        {
            new { Id = 1, Name = "Keyboard", Price = 89.99 },
            new { Id = 2, Name = "Mouse", Price = 49.99 }
        };

        return Ok(products);
    }
}
```

## Learn More

For complete command references, workflow explanations, and additional documentation, visit:

👉 [Bitasmbl Documentation](https://bitasmbl.com/docs)
