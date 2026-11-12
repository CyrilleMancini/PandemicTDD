export function registerMouseDown(dotNetHelper) {
    const handler = (e) => {
        if (e.button !== 1) return; // filtre côté client : pas d'aller-retour pour les autres clics
        dotNetHelper.invokeMethodAsync('OnDocumentMouseDown', e.clientX, e.clientY);
    };
    document.addEventListener('mousedown', handler);
    // Chaque instance reçoit son propre "ticket" pour se désabonner
    return {
        dispose() { document.removeEventListener('mousedown', handler); }
    };
}