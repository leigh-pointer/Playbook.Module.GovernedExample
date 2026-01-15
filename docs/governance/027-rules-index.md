# 027 — Governance Rule Index (Authoritative)

## Purpose

This document is the **authoritative index of enforceable AI governance rules*- for this repository.

It defines **what rules exist**, not how they are implemented.

> 
> **If a rule is not indexed here, it does not exist and MUST NOT be enforced.**
> 

This prevents:

- Invented constraints
- Implicit “best practices”
- AI hallucinating architectural authority

---

## How This Index Is Used

Before generating or modifying code, AI MUST:

1. Read this index
2. Identify relevant rule documents
3. Load and apply only those rules
4. Refuse changes that violate an indexed rule
5. Never enforce rules that are not listed here

If no applicable rule exists:

- The AI MUST NOT invent one
- The AI SHOULD propose a governance rule addition instead

---

## Canonical Reference Source

The **Oqtane Framework source*- is the canonical implementation reference.

This includes (but is not limited to):

- `Oqtane.Client`
- `Oqtane.Server`
- `Oqtane.Shared`
- Built-in modules (e.g. HtmlText, Admin)

Canonical behavior is derived from **existing framework implementations**, not copied reference modules.

AI must:

- Observe
- Compare
- Conform

AI must NOT:

- Reinterpret
- Abstract
- Generalize beyond what exists

---

## Indexed Governance Rules

### Core Governance & Validation

- **027x-canonical-validation.md**

Enforces validation against Oqtane framework patterns and prohibits invention.
- **027x-ai-decision-timeline.md**

Governs when and how AI decisions are recorded as binding memory.

---

### Architecture & Infrastructure

- **027x-scheduled-jobs.md**

Rules for Oqtane Scheduled Jobs (`HostedServiceBase` only).

- **027x-migrations.md**

Database migration rules for multi-database Oqtane modules.

---

### Data & Domain Layer

- **027x-repositories.md**

Repository responsibilities, boundaries, and prohibited logic.

---

### Optional (Opt-In) Rules

- **027x-localization.md**
Governs correct and canonical localization behavior for Oqtane modules once localization is intentionally enabled.

---


### UI & Client Behavior

- **027x-ui-validation.md**

Client-side and server-side validation rules for Razor components.

- **027x-error-handling.md**

Error handling, user feedback, logging, and exception flow rules.

-- **027x-ui-construction.md**
UI construction rules for Razor components and HTML structure.

-- **027x-ui-mudblazor.md**

MudBlazor usage in Oqtane modules **only when explicitly requested**.

-- **027x-ui-radzen.md**

Radzen usage in Oqtane modules **only when explicitly requested**.
---

## Rule Precedence

If multiple rules apply:

1. More specific rule wins
2. Framework implementation wins
3. Governance rules win over AI output
4. AI output always loses conflicts

---

## Rule Creation Policy

AI is **NOT permitted*- to create or enforce new rules.

If a request reveals:

- A missing invariant
- A repeated failure
- An architectural gray area

AI must:

1. Check the AI Decision Timeline
2. If not recorded, recommend adding a new `027x-*` rule
3. Wait for human approval before enforcement

---

## Summary

- This file is the **single source of governance authority**
- It is intentionally boring, explicit, and strict
- Creativity happens **outside enforcement**
- Enforcement happens **only through indexed rules**

This index exists to make AI **predictable, auditable, and trustworthy**.