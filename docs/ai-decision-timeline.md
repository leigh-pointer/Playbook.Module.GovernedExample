# AI Decision Timeline

## Purpose

This document captures **non-trivial AI-assisted decisions** so that:

- Mistakes are not rediscovered
- Framework invariants remain visible
- AI tools are guided by historical context

This is not a chat log.
This is a **governance artifact**.

---

## When to Add an Entry

Add an entry when:

- AI produced plausible but incorrect output
- A framework invariant was rediscovered
- A fix required multiple AI iterations
- The outcome should influence future AI behavior
- A refusal based on architectural or framework constraints
- A correction after multiple iterations
- Identification of an incorrect assumption

The AI MUST:

1. Propose a new entry for `docs/ai-decision-timeline.md`
2. Ask for confirmation before writing
3. Use the canonical entry format

Failure to do so is a governance violation.

Do NOT add entries for trivial fixes.

---

## Entry Format

### YYYY-MM-DD — Short Description

**Context**  
What was being built or fixed.

**Observed Failure**  
What went wrong (symptoms).

**Incorrect Assumption**  
What assumption (human or AI) proved false.

**Root Cause**  
The actual invariant or rule that was violated.

**Correct Pattern**  
The canonical approach that resolved the issue.

**Enforcement Update**  
What rule, instruction, or prompt was updated to prevent recurrence.

---

## Current Status

_No deviations recorded._

### 2026-01-22 — Prefer Oqtane `Pager` for lists in modules

**Context**  
Index page rendering a list of `GovernedExample` items with delete actions in the `Playbook.Module.GovernedExample` module.

**Observed Failure**  
Initial implementation rendered a manual `<table>` without paging instead of using the framework-provided paging control.

**Incorrect Assumption**  
AI assumed a simple static table was acceptable without consulting available `Oqtane.Client` reusable controls.

**Root Cause**  
The implementation omitted reviewing the Oqtane component library; `Pager` exists and is the canonical control for paged lists.

**Correct Pattern**  
Use the Oqtane `Pager` component for list rendering and pagination. Continue to use `ActionDialog` for confirmed deletions and localize all user-facing strings.

**Enforcement Update**  
When rendering lists in Oqtane modules, prefer the `Pager` control from `Oqtane.Client` where paging may be required. AI must check `Oqtane.Client` reusable components before constructing list UI.

The absence of entries indicates full canonical compliance.
