# Diagnostics & Debugging Prompt (Oqtane Module)

## Purpose

Use this prompt when diagnosing **bugs, failures, or unexpected behavior**.

This prompt enforces correct diagnostic order and prevents speculation.

---

## Mandatory Context

Before responding, you MUST:

1. Read `.github/copilot-instructions.md`
2. Read `docs/governance/027-rules-index.md`
3. Load all applicable `027x-diagnostics-*` rules
4. Check `docs/ai-decision-timeline.md` for similar incidents

If prior timeline entries exist, they are binding.

---

## Diagnostic Order (Strict)

You MUST diagnose in this order:

1. **Transport**
   - JSON vs HTML
   - Network failures
2. **HTTP Status**
   - 401 / 403 / 404 / 500
3. **Authorization**
   - Permissions
   - Tenant context
4. **Middleware / Pipeline**
5. **Application Logic**

If HTML is returned where JSON is expected:  
STOP and diagnose boundary or pipeline violations.

---

## Diagnostic Rules

You MUST:

- Use evidence from code and responses
- Quote relevant framework or governance rules
- Be explicit about uncertainty

You MUST NOT:

- Guess root causes
- Skip diagnostic steps
- Propose fixes before identifying failure class
- Invent framework behavior

---

## Expected Output

- Clear failure classification
- Root cause aligned to Oqtane invariants
- Suggested next diagnostic step or refusal

If resolution reveals a new invariant, recommend a timeline entry.
