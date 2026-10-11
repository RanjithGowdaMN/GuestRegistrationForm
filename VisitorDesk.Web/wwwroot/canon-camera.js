(() => {
  const controls = document.createElement('div');
  controls.className = 'settings-actions';
  controls.innerHTML = '<button type="button" id="checkCanon" class="button secondary">Check Canon camera</button><button type="button" id="captureCanon" class="button primary">Capture with Canon</button><button type="button" id="cancelCanon" class="button secondary" hidden>Cancel Canon request</button>';
  $('#cameraMessage').before(controls);
  $('#startCamera').textContent = 'Enable webcam';
  const status = document.createElement('p');
  status.id = 'canonStatus'; status.setAttribute('role', 'status');
  status.textContent = 'Canon EOS 4000D: connect by USB, switch on, select JPEG and close EOS Utility. Use the camera viewfinder to frame the portrait.';
  controls.after(status);
  let request = null;
  let generation = 0;
  function invalidate() { generation++; request?.abort(); }
  // A late capture must never overwrite another visitor or a replacement photo.
  form.addEventListener('reset', invalidate);
  $('#photoUpload').addEventListener('change', invalidate);
  $('#startCamera').addEventListener('click', invalidate);
  $('#cancelCanon').onclick = invalidate;
  async function execute(capture) {
    if (request) return;
    request = new AbortController();
    const current = generation;
    $('#checkCanon').disabled = $('#captureCanon').disabled = true;
    $('#cancelCanon').hidden = false;
    status.textContent = capture ? 'Taking Canon photo… Keep the camera steady.' : 'Checking Canon connection…';
    if (capture) stopCamera();
    try {
      const result = await api('/api/camera/' + (capture ? 'capture' : 'status'), { method: capture ? 'POST' : 'GET', signal: request.signal });
      if (current !== generation) return;
      if (capture) {
        setPhoto(result.image);
        $('#cameraMessage').textContent = 'Canon photo captured. Capture again to retake, or continue to registration.';
      }
      status.textContent = result.message;
    } catch (error) {
      status.textContent = error.name === 'AbortError' ? 'Canon request cancelled.' : error.message;
    } finally {
      request = null;
      $('#checkCanon').disabled = $('#captureCanon').disabled = false;
      $('#cancelCanon').hidden = true;
    }
  }
  $('#checkCanon').onclick = () => execute(false);
  $('#captureCanon').onclick = () => execute(true);
})();
