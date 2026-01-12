# Oqtane UI Rules — Radzen (Opt-In, Enforced)

This rule defines the **only permitted way** to use **Radzen** in Oqtane modules.

Radzen is **NOT part of the default UI stack**.
Its use is allowed **only by explicit opt-in** and does not override
core Oqtane UI governance.

---

## Opt-In Requirement (Non-Negotiable)

Radzen may be used **only if**:

- The developer explicitly requests Radzen in the prompt, AND
- This rule (`027x-ui-Radzen.md`) is acknowledged and applied

If Radzen is not explicitly requested, **default Oqtane UI rules apply**.

**Reject if Radzen is introduced implicitly or by assumption.**

---

## Rule 1: Scope of Use

Radzen may be used for:

- UI components only
- Layout, inputs, dialogs, tables, and visual interaction

Radzen must **NOT** be used to introduce:
- Architectural patterns
- State management abstractions
- Validation pipelines that obscure logic
- Cross-layer coupling

**Reject if Radzen alters application architecture.**

---

## Rule 2: Explicit UI Construction

Even when using Radzen:

- UI intent must remain explicit
- Save logic must be clearly visible
- Validation logic must be readable and local

Allowed:
- RadzenText
- RadzenDropDown
- RadzenButton
- RadzenTemplateForm (with explicit validation handling)

Prohibited:
- Implicit submit behavior
- Hidden validation side effects
- Framework-driven magic flows

**Reject if behavior is implicit or inferred.**

---

## Rule 3: Form Submission Rules

- Buttons must explicitly declare intent
- `type="submit"` is prohibited unless explicitly requested
- Save actions must be bound to explicit handlers

Radzen does **not** relax submission rules.

**Reject if implicit form submission is introduced.**

---

## Rule 4: Validation Rules

Validation must be:

- Visible
- Deterministic
- User-readable

Allowed:
- Radzen validation components
- Manual validation logic

Prohibited:
- Hidden framework validation pipelines
- Validation that cannot be reasoned about from code

**Reject if validation logic is obscured.**

---

## Rule 5: Styling & Consistency

- Radzen styling must be internally consistent
- Do not mix Bootstrap and Radzen within the same UI surface
- Do not partially migrate components

**Reject mixed-framework UI within a single component.**

---

## Rule 6: Canonical Alignment

Radzen usage must still respect:

- Oqtane client/server boundaries
- Service usage rules
- Error handling rules
- Authorization rules

Radzen is a **visual layer only**.

**Reject if Radzen bypasses governance in other domains.**

---

## Rule 7: Default Still Wins

The existence of this rule does **not** change defaults.

Default UI stack remains:

- Bootstrap
- Explicit HTML
- ActionLink navigation
- No EditForm

Radzen is an **exception**, not an alternative default.

---

## Validation Checklist

Radzen usage is valid only if:

- Explicitly requested
- This rule is applied
- UI logic remains explicit
- Validation is visible
- Submission intent is declared
- No architectural side effects exist
- No framework mixing occurs

If any check fails, **reject the change**.

---

This rule exists to allow **controlled, intentional UI extension**
without weakening Oqtane’s architectural integrity.
