# UI Construction Prompt (Oqtane Module)

## Purpose

Use this prompt when creating or modifying **any UI component** in this module.

This prompt enforces Oqtane UI rules and module-specific governance.

---

## Mandatory Context

Before responding, you MUST:

1. Read `.github/copilot-instructions.md`
2. Read `docs/governance/027-rules-index.md`
3. Load all applicable `027x-ui-*` rule documents
4. Check `docs/ai-decision-timeline.md` for relevant prior decisions

If any file is missing or inaccessible, STOP and refuse.

---

## UI Construction Rules (Non-Negotiable)

You MUST:

- Use **explicit HTML elements only**
  - `<form>`, `<input>`, `<select>`, `<textarea>`
- Use **Bootstrap classes** for layout and styling
- Use **Bootstrap Icons** where icons are required
- Declare `type="button"` on ALL buttons
- Implement validation explicitly and visibly in code
- Use `ActionLink` for navigation when applicable
- Keep UI logic in the Razor component only

You MUST NOT:

- Use `EditForm` (unless explicitly instructed)
- Use implicit Blazor validation abstractions
- Use `type="submit"` unless explicitly requested
- Hide validation or save behavior
- Introduce routing via `@page`
- Introduce business logic or persistence

---

## Expected Output

- A Razor component fragment
- Explicit HTML markup
- Explicit validation logic
- No invented abstractions

If uncertain, REFUSE and explain why.
