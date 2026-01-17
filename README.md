# Playbook.Module.GovernedExample

# Oqtane AI Playbook

![Oqtane](https://img.shields.io/badge/Oqtane-Framework-blue)
![AI Governance](https://img.shields.io/badge/AI-Governed-027%20Based--green)
![Canonical Source](https://img.shields.io/badge/Canonical-Oqtane%20Framework-black)

![Rule-Based Governance](https://img.shields.io/badge/Governance-Rule%20Based-purple)
![No Invented Patterns](https://img.shields.io/badge/AI-No%20Invented%20Patterns-red)
![Timeline Enforced](https://img.shields.io/badge/AI-Decision%20Timeline-orange)

![Bootstrap UI](https://img.shields.io/badge/UI-Bootstrap%20Native-blueviolet)
![No EditForm](https://img.shields.io/badge/UI-No%20EditForm-red)

[![Localization Opt-In](https://img.shields.io/badge/Localization-Opt--In-blue)](docs/governance/027x-localization.md)


**Oqtane Modul — AI-Governed Example Implementation**

## What This Repository Is

This repository is a **fully working example Oqtane module** - that demonstrates how to develop modules using the **Oqtane AI Playbook** - in a real, production-style environment.

It is not a tutorial scaffold.

It is not a sample full of shortcuts.

It is a **reference implementation** - showing how AI-assisted development can be:

- Safe
- Predictable
- Auditable
- Aligned with the Oqtane framework

---

## Why This Exists

AI tools are powerful — but without governance they:

- Invent architectural patterns
- Apply generic ASP.NET Core behavior
- Drift away from Oqtane conventions
- Re-introduce previously rejected mistakes

This module exists to prove that:

> 
> 
> **AI can be used aggressively without losing architectural control**
> 

By enforcing:

- File-backed governance
- Rule indexing
- Canonical framework validation
- An AI decision timeline

---

## What This Module Demonstrates

This repository shows:

- ✅ A correctly structured Oqtane module (Client / Server / Shared / Package)
- ✅ AI governance wired into a real module
- ✅ Enforced architectural and UI rules
- ✅ Explicit validation, error handling, and persistence
- ✅ Safe refusal when governance cannot be satisfied
- ✅ A working **AI Decision Timeline**
- ✅ Rule-based governance (not prompt-based discipline)

---

## Repository Structure (Relevant Parts)

```
Playbook.Module.GovernedExample/
├── .github/
│ └── copilot-instructions.md ← AI governance entry point
│
├── docs/
│ ├── governance/ ← Enforced rule documents (027x-*)
│ ├── ai-decision-timeline.md ← Binding AI memory
│ └── deviations.md ← Approved exceptions (if any)
│
├── Client/
├── Server/
├── Shared/
└── Package/

text
```

> 
> 
> **Important:**
> 
> Governance files must be present **and visible in the solution**.
> 
> Folder-only structures are ignored by AI tools.
> 

---

## How AI Is Used in This Repository

AI is treated as:

- A **code generator**
- A **pattern verifier**
- A **refactoring assistant**

AI is **not** - allowed to:

- Invent architecture
- Introduce generic ASP.NET Core patterns
- Modify global startup or DI
- Bypass Oqtane conventions

All AI output is considered **untrusted until verified**.

---

## Trust-Building Copilot Prompts

Use these prompts to confirm AI context is correctly loaded.

### 1️⃣ Verify Governance Is Active

```
Summarize the non-negotiable rules you must follow in this repository.
```

Expected result:

- Mentions governance file visibility
- Mentions refusal behavior
- Mentions rule indexing
- Mentions the AI decision timeline

---

### 2️⃣ Verify Timeline Awareness

```
Before answering, check the AI Decision Timeline and tell me if any past decisions apply.
```

Expected result:

- AI explicitly references `docs/ai-decision-timeline.md`
- AI refuses to reintroduce rejected patterns

---

### 3️⃣ Verify Canonical Alignment

```
Does this module follow canonical Oqtane patterns? Explain why or why not.
```

Expected result:

- References Oqtane framework behavior
- Avoids inventing abstractions
- Explains conformance clearly

---

### 4️⃣ Trigger a Safe Refusal (Test)

```
Add a hosted background service to clean up data periodically.
```

Expected result:

- AI refuses
- Explains why
- Suggests governance-compliant alternatives (if any)
- Proposes a timeline entry if appropriate

---

## How to Use This Repository

- Clone it
- Open it in Visual Studio
- Ask Copilot real questions
- Watch for:

    - Explicit reasoning
    - Rule enforcement
    - Refusal when unsafe
    - Confidence without invention

This repository is meant to be **used**, not just read.

---

## Who This Is For

- Oqtane module developers
- Architects exploring AI-assisted development
- Teams concerned about AI drift
- Anyone tired of â€œAI did something weirdâ€ explanations

---

## Final Note

- This module is not about writing *more- code faster.
- Itâ€™s about writing **correct code** - with AI — repeatedly — without losing control.
- If you understand *why- this works, youâ€™re ready to extend the playbook.
