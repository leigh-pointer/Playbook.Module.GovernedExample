# Governance Rules

![Rule-Based Governance](https://img.shields.io/badge/Governance-Rule%20Based-purple)
![No Invented Patterns](https://img.shields.io/badge/AI-No%20Invented%20Patterns-red)
![Timeline Enforced](https://img.shields.io/badge/AI-Decision%20Timeline-orange)

This folder contains the **enforceable AI governance rules** for this repository.

These rules exist to ensure that:
- AI-generated code follows Oqtane's architectural constraints
- Invalid patterns are rejected early
- Decisions are consistent, reviewable, and repeatable
- Previously rejected approaches are not reintroduced

This is **governance as code**, not guidance.

---

## How Governance Works

This repository uses a **rule reference model**.

- Rules are **file-backed**
- Only files listed in `027-rules-index.md` are enforceable
- AI must discover and apply relevant rules before generating or modifying code
- If no applicable rule exists, AI must **refuse or propose a new rule**

AI is **not permitted to invent rules**.

---

## Required Files

### 1. `027-rules-index.md`
The authoritative index of all enforceable rules.

- Defines **what rules exist**
- Defines **when rules apply**
- Controls **rule discovery**

If a rule is not indexed, it does not exist.

---

### 2. `027x-*` Rule Files

Each `027x-*` file defines **enforceable rules** for a specific domain.

Rule files must:
- Be explicit
- Contain rejection criteria
- Be enforceable without interpretation
- Avoid recommendations or 'best practices'

Examples:
- `027x-core-ai-behavior.md`
- `027x-authorization.md`
- `027x-scheduled-jobs.md`

---

## UI Framework Policy

This playbook is **Oqtane-first**.

By default, all UI guidance follows:
- Bootstrap
- Explicit HTML elements
- Visible validation and save logic
- Canonical Oqtane UI patterns

Alternative UI frameworks (such as MudBlazor) are **not enabled by default**.

They may be used **only by explicit opt-in** and are governed by
dedicated rule documents (for example: `027x-ui-mudblazor.md`).

If a framework is not explicitly requested and governed,
it must not be introduced.

---

## Rule Enforcement Order

When rules conflict, precedence is:

1. Canonical module reference
2. Domain-specific rule
3. General rule
4. AI output (always loses)

---

## AI Decision Timeline

Historical decisions and invariants are recorded in:

`/docs/ai-decision-timeline.md`


AI must:
- Read the timeline before non-trivial responses
- Not reintroduce rejected patterns
- Propose new entries when a refusal or invariant occurs

Timeline entries are **append-only**.

---

## Governance File Visibility (Critical)

This playbook **does not require copying files** into every module.

What matters is **IDE visibility**, not physical location.

### Supported Model (Recommended)

Governance and prompt files may live **anywhere on disk**, as long as:

* They are added to the module **solution** as *existing documents*
* They appear under a `docs/` solution folder
* Copilot can *read* them at prompt time

### Example (Linked Files)

A module solution may include:

```
docs/
├── governance/
│   ├── 027-rules-index.md
│   ├── 027x-ui-construction.md
│   ├── 027x-migrations.md
│   └── ...
└── prompts/
    ├── ui.md
    ├── services.md
    └── diagnostics.md
```

These files may be **linked** from another folder or repository:

```
<Folder Name="/docs/governance/">
  <File Path="..\..\..\Oqtane-AI-Playbook\docs\governance\027-rules-index.md" />
</Folder>
```



---

## Adding or Changing Rules

AI **cannot** add or modify rules directly.

To introduce new governance:
1. Propose a rule document
2. Review with maintainers
3. Add the rule to `027-rules-index.md`
4. Commit the rule file

Only then does the rule become enforceable.

---

## Enforcement Statement

Failure to follow governance rules invalidates AI output.

When in doubt:
- Reject
- Explain why
- Reference the governing rule

This folder is binding.

