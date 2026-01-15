# 027x - Localization and String Resources

## Activation

This rule is **opt-in**.

It becomes **mandatory and fully enforced** if ANY of the following are true:

- The module declares support for multiple languages
- Any `.resx` resource file exists in the module
- `IStringLocalizer<T>` is injected anywhere in the module
- `LocalizableComponent` is inherited
- The module is marked as “Localized” in documentation or prompts

Once activated:
- ALL user-facing strings MUST be localized
- Mixed localized / hardcoded UI is forbidden
- Partial localization is NOT allowed

## Authority
This rule is derived from canonical Oqtane Framework patterns observed in:
- `Oqtane.Client/Resources/` structure (Modules, Controls, Admin hierarchy)
- `Oqtane.Client/Modules/HtmlText/` (Index.razor, Edit.razor, Settings.razor)
- `Oqtane.Client/Modules/Controls/` (ActionDialog, ActionLink, FileManager, Label, Section)
- `Oqtane.Client/Modules/Controls/LocalizableComponent.cs` (base class for controls)
- `Oqtane.Client/Modules/Admin/Users/Add.razor` (comprehensive example)
- `Oqtane.Server/Resources/Managers/UserManager.resx` (server-side email templates)

## Rule: String Resource Organization

### Resource File Structure

**Client Resources:**
```
Client/Resources/
├── Modules/
│   ├── {ModuleName}/
│   │   ├── ComponentName.resx      (per-component resources)
│   │   └── Settings.resx           (settings component)
│   └── Admin/
│       ├── Users/
│       │   ├── Add.resx
│       │   ├── Edit.resx
│       │   └── Index.resx
│       └── (other admin modules)
├── Controls/
│   └── FileManager.resx            (shared control resources)
└── SharedResources.resx            (framework-wide shared strings)
```

**Server Resources:**
```
Server/Resources/
├── Managers/
│   └── ManagerName.resx            (email templates, server messages)
└── Infrastructure/
    └── SiteTemplates/
        └── AdminSiteTemplate.resx
```

### Resource Key Naming Conventions

#### 1. Action Keys
Format: `{Action}.{Context}`
```xml
<data name="Edit.Action" xml:space="preserve">
  <value>Edit Content</value>
</data>
```

#### 2. Error Keys
Format: `Error.{Entity}.{Operation}`
```xml
<data name="Error.Content.Load" xml:space="preserve">
  <value>An Error Occurred Loading Content</value>
</data>
<data name="Error.Content.Save" xml:space="preserve">
  <value>Error Saving Content</value>
</data>
<data name="Error.File.Upload" xml:space="preserve">
  <value>File Upload Failed</value>
</data>
<data name="Error.User.Add" xml:space="preserve">
  <value>Error Adding User</value>
</data>
```

#### 3. Success Keys
Format: `Success.{Entity}.{Operation}`
```xml
<data name="Success.File.Delete" xml:space="preserve">
  <value>File Deleted</value>
</data>
<data name="Success.File.Upload" xml:space="preserve">
  <value>File Uploaded Successfully</value>
</data>
```

#### 4. Message Keys
Format: `Message.{Entity}.{Context}`
```xml
<data name="Message.File.NotSelected" xml:space="preserve">
  <value>You Have Not Selected A File To Upload</value>
</data>
<data name="Message.Content.Restored" xml:space="preserve">
  <value>Content Restored Successfully</value>
</data>
<data name="Message.Content.Deleted" xml:space="preserve">
  <value>Content Deleted Successfully</value>
</data>
<data name="Message.Required.ProfileInfo" xml:space="preserve">
  <value>You Must Provide A Username, Email Address And All Required Profile Information</value>
</data>
```

#### 5. Confirmation Keys
Format: `Confirm.{Action}`
```xml
<data name="Confirm.Delete" xml:space="preserve">
  <value>Are you sure you want to delete the version created on {0}?</value>
</data>
<data name="Confirm.Restore" xml:space="preserve">
  <value>Are you sure you want to restore the version created on {0}?</value>
</data>
```

#### 6. UI Element Keys (for Label control with ResourceKey)
Format: `{PropertyName}.Text` and `{PropertyName}.HelpText`
```xml
<data name="Username.Text" xml:space="preserve">
  <value>Username:</value>
</data>
<data name="Username.HelpText" xml:space="preserve">
  <value>A unique username for a user. Note that this field can not be modified once it is saved.</value>
</data>
<data name="Email.Text" xml:space="preserve">
  <value>Email:</value>
</data>
<data name="Email.HelpText" xml:space="preserve">
  <value>The email address where the user will receive notifications</value>
</data>
```

#### 7. TabPanel Names (for TabStrip ResourceKey)
Format: `{TabName}.Name`
```xml
<data name="Identity.Name" xml:space="preserve">
  <value>Identity</value>
</data>
<data name="Profile.Name" xml:space="preserve">
  <value>Profile</value>
</data>
```

### Localizer Injection Patterns

**Component-Specific Localizer:**
```csharp
@inject IStringLocalizer<Edit> Localizer

// Usage:
AddModuleMessage(Localizer["Error.Content.Load"], MessageType.Error);
string.Format(Localizer["Confirm.Delete"], context.CreatedOn)
```

**SharedResources Localizer (for common UI elements):**
```csharp
@inject IStringLocalizer<SharedResources> SharedLocalizer

// Usage:
<button>@SharedLocalizer["Save"]</button>
<button>@SharedLocalizer["Cancel"]</button>
<button>@SharedLocalizer["Upload"]</button>
<button>@SharedLocalizer["Delete"]</button>
<th>@SharedLocalizer["CreatedOn"]</th>
<th>@SharedLocalizer["CreatedBy"]</th>
<option value="true">@SharedLocalizer["Yes"]</option>
<option value="false">@SharedLocalizer["No"]</option>
```

**LocalizableComponent Pattern (for Controls):**
```csharp
@inherits LocalizableComponent

protected override void OnParametersSet()
{
    base.OnParametersSet(); // REQUIRED - must call base method
    
    // Localize parameters using ResourceKey
    Text = Localize(nameof(Text), Text);
    Header = Localize(nameof(Header), Header);
    Message = Localize(nameof(Message), Message);
    HelpText = Localize(nameof(HelpText), HelpText);
}
```

**How LocalizableComponent Works:**
- Requires `ResourceKey` and `ResourceType` parameters
- Looks up `{ResourceKey}.{PropertyName}` in resource file
- Falls back to property value if key not found
- Used by Label, Section, ActionDialog, ActionLink controls

**Server-Side Localizer:**
```csharp
@inject IStringLocalizer<UserManager> Localizer

var subject = Localizer["ForgotPasswordEmailSubject"];
var body = Localizer["ForgotPasswordEmailBody"];
```

## Prohibited Patterns

### ❌ NEVER hardcode user-facing strings
```csharp
// WRONG
AddModuleMessage("Error loading content", MessageType.Error);
<span class="badge">Draft</span>
<button>Save</button>
<button>Cancel</button>

// CORRECT
AddModuleMessage(Localizer["Error.Content.Load"], MessageType.Error);
<span class="badge">@Localizer["WorkflowState.Draft"]</span>
<button>@SharedLocalizer["Save"]</button>
<button>@SharedLocalizer["Cancel"]</button>
```

### ❌ NEVER use generic resource keys
```csharp
// WRONG
Localizer["Error"]
Localizer["Message1"]

// CORRECT
Localizer["Error.Document.Load"]
Localizer["Message.File.NotSelected"]
```

### ❌ NEVER mix localized and hardcoded strings
```csharp
// WRONG
<button>@SharedLocalizer["Save"]</button>
<button>Cancel</button>  // Hardcoded!
<span class="badge">@Localizer["WorkflowState.Draft"]</span>
<span class="badge">Pending Review</span>  // Hardcoded!

// CORRECT
<button>@SharedLocalizer["Save"]</button>
<button>@SharedLocalizer["Cancel"]</button>
<span class="badge">@Localizer["WorkflowState.Draft"]</span>
<span class="badge">@Localizer["WorkflowState.PendingReview"]</span>
```

### ❌ NEVER include emoji in UI strings
```csharp
// WRONG
AddModuleMessage("✓ Document checked in successfully", MessageType.Success);
AddModuleMessage("🔒 Document is locked", MessageType.Warning);

// CORRECT
AddModuleMessage(Localizer["Success.Document.CheckIn"], MessageType.Success);
AddModuleMessage(Localizer["Message.Document.Locked"], MessageType.Warning);
```

## Required Patterns

### ✅ All UI strings MUST be in .resx files
- Button labels
- Error messages
- Success messages
- Validation messages
- Placeholder text
- Tooltip text
- Badge text
- Modal titles/messages
- Dropdown options (except Yes/No which use SharedLocalizer)

### ✅ Resource keys MUST be descriptive
- Use dot notation for hierarchy
- Include context (Error/Success/Message)
- Include entity and operation

### ✅ Preserve xml:space attribute
```xml
<data name="KeyName" xml:space="preserve">
  <value>String Value</value>
</data>
```

## Control Components and ResourceKey

### Label Control with ResourceKey
```csharp
<Label Class="col-sm-3" 
       For="username" 
       HelpText="A unique username for a user. Note that this field can not be modified once it is saved." 
       ResourceKey="Username">
</Label>
```

**Resource file entries:**
```xml
<data name="Username.Text" xml:space="preserve">
  <value>Username:</value>
</data>
<data name="Username.HelpText" xml:space="preserve">
  <value>A unique username for a user...</value>
</data>
```

### Section Control with ResourceKey
```csharp
<Section Name="Advanced" 
         Heading="Advanced Settings" 
         ResourceKey="Advanced" 
         Expanded="false">
    <!-- content -->
</Section>
```

**Resource file entries:**
```xml
<data name="Advanced.Heading" xml:space="preserve">
  <value>Advanced Settings</value>
</data>
```

### TabStrip and TabPanel ResourceKey
```csharp
<TabStrip>
    <TabPanel Name="Edit" Heading="Edit" ResourceKey="Edit">
        <!-- content -->
    </TabPanel>
    <TabPanel Name="Versions" Heading="Versions" ResourceKey="Versions">
        <!-- content -->
    </TabPanel>
</TabStrip>
```

### ActionDialog and ActionLink
```csharp
<ActionDialog Header="Delete Version" 
              Message="@string.Format(Localizer[\"Confirm.Delete\"], context.CreatedOn)" 
              Action="Delete" 
              ResourceKey="Delete" />

<ActionLink Action="View" 
            Security="SecurityAccessLevel.Edit" 
            OnClick="@(async () => await View(context))" 
            ResourceKey="View" />
```

### Settings.razor Pattern
```csharp
@inject IStringLocalizer<Settings> Localizer
@inject IStringLocalizer<SharedResources> SharedLocalizer

private string resourceType = "Oqtane.Modules.HtmlText.Settings, Oqtane.Client";

<Label Class="col-sm-3" 
       For="dynamictokens" 
       ResourceKey="DynamicTokens" 
       ResourceType="@resourceType" 
       HelpText="Do you wish to allow tokens to be dynamically replaced?">
    Dynamic Tokens?
</Label>
<select>
    <option value="true">@SharedLocalizer["Yes"]</option>
    <option value="false">@SharedLocalizer["No"]</option>
</select>
```

**Key Pattern:**
- Settings components define `resourceType` variable for Label ResourceType
- Use SharedLocalizer for Yes/No, common options
- Use component Localizer for component-specific messages

## Validation Checklist

Before committing code, verify:
- [ ] No hardcoded user-facing strings in .razor files
- [ ] No hardcoded button text (Save, Cancel, Delete, Upload, etc.)
- [ ] No hardcoded badge text (workflow states, statuses)
- [ ] No hardcoded success/error messages
- [ ] No emoji in UI strings (✓, ✗, 🔒, 🔓)
- [ ] No hardcoded Yes/No options (use SharedLocalizer["Yes"], SharedLocalizer["No"])
- [ ] All Localizer keys exist in corresponding .resx file
- [ ] Resource keys follow naming conventions (Error.*, Success.*, Message.*, Confirm.*)
- [ ] Resource file matches component name (Add.razor → Add.resx)
- [ ] IStringLocalizer<ComponentName> injected for component-specific strings
- [ ] IStringLocalizer<SharedResources> injected for common UI elements
- [ ] Controls inheriting LocalizableComponent call base.OnParametersSet()
- [ ] Label controls use ResourceKey with .Text and .HelpText entries
- [ ] TabPanel uses ResourceKey with .Name entry
- [ ] All .resx entries include xml:space="preserve"
- [ ] Confirmation messages use string.Format for parameters
- [ ] Server-side email templates in Server/Resources/Managers/
- [ ] Settings components define resourceType variable for Label ResourceType

## Exception Cases

### Technical strings (allowed to be hardcoded):
- CSS class names
- HTML attributes
- API endpoint paths
- Configuration keys
- Enum values (internal)
- Log messages (developer-facing)

### Framework constants (use existing):
- `PermissionNames.*`
- `RoleNames.*`
- `IconConstants.*`
- `MessageType.*`
- `SecurityAccessLevel.*`

## Enforcement

AI assistants MUST:
1. Reject code with hardcoded user-facing strings
2. Suggest appropriate resource key names
3. Verify resource file structure matches Oqtane patterns
4. Check for existing similar keys before creating new ones
5. Verify LocalizableComponent base.OnParametersSet() is called
6. Verify Label controls use ResourceKey pattern
7. Verify SharedLocalizer used for Yes/No and common buttons

## References
- Oqtane.Client/Resources/ (canonical structure with Admin hierarchy)
- Oqtane.Client/Modules/HtmlText/ (reference implementation: Index, Edit, Settings)
- Oqtane.Client/Modules/Admin/Users/Add.razor (comprehensive Label/ResourceKey example)
- Oqtane.Client/Modules/Controls/LocalizableComponent.cs (base class for controls)
- Oqtane.Client/Modules/Controls/ (ActionDialog, ActionLink, Label, Section patterns)
- Oqtane.Server/Resources/Managers/UserManager.resx (email template patterns)
- Microsoft.Extensions.Localization documentation
