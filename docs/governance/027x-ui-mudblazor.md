# MudBlazor UI Construction (Opt-In)

This rule enables MudBlazor usage in Oqtane modules **only when explicitly requested**.

MudBlazor is NOT the default UI framework.

---

## Rule 1: Explicit Opt-In Required

MudBlazor components may be used **only if** the user prompt includes one of:

- "Use MudBlazor"
- "MudBlazor UI"
- "Mud components"

If not explicitly requested, **reject MudBlazor usage**.

---

## Rule 2: No Mixing Frameworks

When MudBlazor is enabled:

- Do NOT mix Bootstrap form controls with Mud components
- Layout must be consistent with MudBlazor patterns

---

## Rule 3: Explicit Save Flow Still Required

Even when using MudBlazor:

- Save actions must be explicit
- Button click handlers must be visible
- No implicit submit behavior

**Reject if:**
- Save logic is hidden in framework callbacks
- Form submission is implicit

---

## Rule 4: Validation Transparency

Validation rules must be visible and readable:

- Inline validation preferred
- No “magic” validation without explanation

---

## Rule 5: Dependency Declaration

MudBlazor usage must document:

- Required NuGet packages
- Required service registrations
- Impact on module footprint
