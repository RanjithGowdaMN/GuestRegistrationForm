(() => {
  const main = $('main');
  // Move the existing capture controls, preserving their state and event handlers.
  const scanCard = $('.scanner-card'), photoCard = $('#cameraBox').closest('article');
  const banner = $('.identity-banner');
  main.insertBefore(banner, $('#registration'));
  function page(id, eyebrow, title, description) {
    const section = document.createElement('section'); section.id=id; section.hidden=true;
    section.innerHTML=`<div class="heading"><div><div class="eyebrow">${eyebrow}</div><h1>${title}</h1><p>${description}</p></div><span class="workspace-label">RECEPTION WORKSPACE</span></div>`;
    main.insertBefore(section, $('#registration'));return section;
  }
  const dashboard=page('dashboard','YOUR RECEPTION, AT A GLANCE','Welcome to VISMA.','A clear view of your facility. A seamless welcome for every visitor.');
  dashboard.innerHTML+=`<div class="dashboard-stats"><article class="card"><span>Arrivals today</span><strong id="dashToday">—</strong><small>Visitors registered today</small></article><article class="card"><span>Currently on site</span><strong id="dashOnsite">—</strong><small>Checked in, awaiting departure</small></article><article class="card"><span>Departures today</span><strong id="dashDeparted">—</strong><small>Visitors checked out today</small></article><article class="card"><span>Total registrations</span><strong id="dashTotal">—</strong><small>All recorded visits</small></article></div><div class="dashboard-heading"><h2>Reception shortcuts</h2><span>One visitor. One connected workflow.</span></div><div class="quick-actions"><button class="card quick-action" data-page="scan"><span class="quick-icon">▤</span><span class="quick-number">01 / CAPTURE</span><h2>Scan identity document</h2><p>Scan front and back, crop and rotate.</p><strong>Open scanning studio →</strong></button><button class="card quick-action" data-page="photo"><span class="quick-icon">◎</span><span class="quick-number">02 / PHOTO</span><h2>Visitor photo</h2><p>Capture a clear portrait for the record.</p><strong>Open photo studio →</strong></button><button class="card quick-action" data-page="registration"><span class="quick-icon">＋</span><span class="quick-number">03 / REGISTER</span><h2>Complete registration</h2><p>Confirm details, sign and check in.</p><strong>Open visitor form →</strong></button></div><div class="dashboard-bottom"><article class="card"><div class="section-heading"><div><h2>Recent arrivals</h2><p>Your latest visitor activity</p></div><button class="text-button" data-page="log">View visitor log ↗</button></div><div id="recentArrivals"><p>Loading visitor activity…</p></div></article><article class="card draft-card"><div class="eyebrow">CURRENT VISITOR</div><h2>Registration progress</h2><p>Your draft stays with you as you move between tabs.</p><div id="draftProgress"></div><button class="button primary" data-page="registration">Continue registration →</button></article></div>`;
  const scan=page('scan','01 / IDENTITY CAPTURE','Scan identity document','Two sides. One complete record. Capture and refine the visitor’s ID.');
  scan.classList.add('studio-page');scan.append(scanCard);
  const scanFooter=document.createElement('div');scanFooter.className='studio-footer';scanFooter.innerHTML='<span>Scan the front, flip the ID and reinsert it for the back.</span><button class="button primary" data-page="photo">Continue to visitor photo →</button>';scan.append(scanFooter);
  const photoPage=page('photo','02 / PORTRAIT CAPTURE','Visitor photo','Give every visitor record a face. Capture a clear, well-lit portrait.');
  photoPage.classList.add('studio-page');
  const photoLayout=document.createElement('div');photoLayout.className='photo-studio-layout';photoLayout.append(photoCard);
  const guide=document.createElement('article');guide.className='card photo-guide';guide.innerHTML='<div class="eyebrow">A GOOD PHOTO, EVERY TIME</div><h2>Ready for their close-up.</h2><div><b>01</b><span>Face the camera<small>Keep the visitor’s full face in the frame.</small></span></div><div><b>02</b><span>Find even lighting<small>Avoid a bright window behind the visitor.</small></span></div><div><b>03</b><span>Capture and review<small>Retake the photo whenever you need to.</small></span></div><p>Using the laptop camera. You can also upload an existing visitor photo.</p>';photoLayout.append(guide);photoPage.append(photoLayout);
  const photoFooter=document.createElement('div');photoFooter.className='studio-footer';photoFooter.innerHTML='<button class="button secondary" data-page="scan">← Back to identity scan</button><button class="button primary" data-page="registration">Continue to registration →</button>';photoPage.append(photoFooter);
  $('.capture-grid').remove();
  const pages={dashboard,scan,photo:photoPage,registration:$('#registration'),log:$('#log')};
  const names={dashboard:'Dashboard',scan:'Scan',photo:'Photo',registration:'Verify/New',log:'Visitor log'};
  const navs={dashboard:$('#dashboardNav'),scan:$('#scanNav'),photo:$('#photoNav'),registration:$('#registrationNav'),log:$('#logNav')};
  for(const [id,label,description] of [
    ['settings','Settings','Manage departments, employees and reception configuration.'],
    ['chip','Read ID chip','Read identity details from the connected card reader.'],
    ['documents','Document filling','Fill the original visitor or contractor PDF using the current identity details.'],
    ['cards','ID card printing','Prepare a visitor or contractor card for review and printing.']]) {
    pages[id]=page(id,'RECEPTION WORKSPACE',label,description); names[id]=label;
    const button=document.createElement('button');button.className='nav';button.textContent=label;
    $('#logNav').before(button);navs[id]=button;
  }
  const sidebarOrder=['dashboard','scan','photo','chip','registration','documents','cards','log','settings'];
  const sidebarLabels={dashboard:'Dashboard',scan:'Scan',photo:'Photo',chip:'Read Chip',registration:'Verify/New',documents:'Document filling',cards:'ID card Printing',log:'Visitor log',settings:'Settings'};
  for(const id of sidebarOrder){
    const label=navs[id].querySelector('span');
    if(label)label.textContent=sidebarLabels[id];else navs[id].textContent=sidebarLabels[id];
    $('.aside-bottom').before(navs[id]);
  }
  pages.chip.innerHTML+='<article class="card fields-card"><h2>Identity card reader</h2><p id="chipMessage" role="status">Check the connected reader and card before reading.</p><button id="checkChip" class="button primary">Check reader and card</button><div id="chipReaders"></div><button id="readChip" class="button primary">Read identity details</button><div id="chipReview" hidden></div><button id="applyChip" class="button secondary" hidden>Apply empty fields to registration</button><button class="button secondary" data-page="scan">Open identity scan</button></article>';
  pages.documents.innerHTML+='<article class="card fields-card"><div class="fields"><label>Document template<select id="documentTemplate"><option value="visitor">Visitor</option><option value="contractor">Contractor</option></select></label><label>Identity document<select id="documentIdentityType"><option value="qid">Qatar ID</option><option value="passport">Passport</option></select></label></div><p>Identity, company, host and purpose come from the current registration. Verify them before generating.</p><div id="documentFields" class="fields"></div><button id="generateDocument" class="button primary">Generate PDF preview</button><p id="documentMessage" role="status"></p><a id="documentDownload" class="button secondary" hidden>Download filled PDF</a><iframe id="documentPreview" title="Filled document preview" hidden style="width:100%;height:700px;border:0"></iframe><button class="button secondary" data-page="cards">Continue to card printing →</button></article>';
  for(const [key,label] of Object.entries({title:'Job title',area:'Area to visit',duration:'Visit duration',visitDate:'Visit date',departmentManager:'Department manager',productionManager:'Production manager',securityController:'Security controller',address:'Address',city:'City',state:'State',zip:'Postal code',email:'Email',homePhone:'Home phone',securityNo:'Security number',felony:'Convicted felony (Yes / No)',passportNumber:'Passport number',passportPlace:'Passport place of issue',passportIssued:'Passport issue date',passportExpiry:'Passport expiry',emergencyPhone:'Emergency contact',alias:'Alias',residence:'Permanent residence'})) {
    const labelNode=document.createElement('label');labelNode.textContent=label;
    const input=document.createElement('input');input.dataset.documentField=key;input.maxLength=200;
    if(['visitDate','passportIssued','passportExpiry'].includes(key))input.type='date';
    labelNode.append(input);$('#documentFields').append(labelNode);
  }
  pages.cards.innerHTML+='<article class="card fields-card"><div class="fields"><label>Card template<select id="cardType"><option>VISITOR</option><option>CONTRACTOR</option></select></label><label>Card number<input id="cardNumber" maxlength="30" required></label></div><p>The card uses the current visitor name and portrait with the existing card layout. Review the PDF, then use its print dialog with the card printer and actual-size scaling.</p><button id="generateCard" class="button primary">Generate card preview</button><p id="cardMessage" role="status"></p><a id="cardDownload" class="button secondary" hidden>Download card PDF</a><iframe id="cardPreview" title="ID card print preview" hidden style="width:100%;height:420px;border:0"></iframe></article>';
  const urls={};
  window.clearDocumentPreviews=()=>{for(const prefix of ['document','card']){if(urls[prefix]){URL.revokeObjectURL(urls[prefix]);delete urls[prefix];}$(`#${prefix}Preview`).removeAttribute('src');$(`#${prefix}Preview`).hidden=true;$(`#${prefix}Download`).hidden=true;$(`#${prefix}Download`).removeAttribute('href');$(`#${prefix}Message`).textContent='';}};
  async function generateOutput(card) {
    const prefix=card?'card':'document',button=$(card?'#generateCard':'#generateDocument');
    const details=Object.fromEntries([...document.querySelectorAll('[data-document-field]')].map(input=>[input.dataset.documentField,input.value]));
    const data=window.documentWorkflow.payload(card);
    const version=window.documentWorkflow.version;
    if(!data.name.trim()||!data.idNumber.trim())return notify('Enter the visitor name and ID number in registration first.');
    if(card&&(!data.photo||!data.cardNumber.trim()))return notify('Capture a portrait and enter a card number first.');
    button.disabled=true;$(`#${prefix}Message`).textContent='Generating PDF…';
    $(`#${prefix}Preview`).hidden=true;$(`#${prefix}Download`).hidden=true;
    try {
      const response=await fetch('/api/documents',{method:'POST',headers:{'Content-Type':'application/json'},body:JSON.stringify(data)});
      if(!response.ok){const result=await response.json();throw new Error(result.error||'Unable to generate PDF.');}
      const blob=await response.blob();if(version!==window.documentWorkflow.version)return;if(urls[prefix])URL.revokeObjectURL(urls[prefix]);urls[prefix]=URL.createObjectURL(blob);
      const preview=$(`#${prefix}Preview`),download=$(`#${prefix}Download`);preview.src=urls[prefix];preview.hidden=false;download.href=urls[prefix];download.download=`${data.template}.pdf`;download.hidden=false;
      $(`#${prefix}Message`).textContent='Ready for review. Use the PDF print control when the details are correct.';
    }catch(error){$(`#${prefix}Message`).textContent=error.message;}finally{button.disabled=false;}
  }
  $('#generateDocument').onclick=()=>generateOutput(false);$('#generateCard').onclick=()=>generateOutput(true);
  let active='dashboard';
  window.openWorkspace = name => {
    if(!pages[name])return;
    if(active==='photo' && name!=='photo')stopCamera();
    active=name;
    for(const [key,section] of Object.entries(pages)){section.hidden=key!==name;navs[key].classList.toggle('active',key===name);if(key===name)navs[key].setAttribute('aria-current','page');else navs[key].removeAttribute('aria-current');}
    $('#breadcrumb').textContent=names[name];
    if(name==='documents'||name==='cards')window.documentWorkflow?.enter();
    if(name==='dashboard'){renderDashboard();refresh().catch(error=>{notify(error.message);$('#recentArrivals').textContent='Visitor activity could not be loaded. Reopen the dashboard to retry.';});}
    window.scrollTo({top:0,behavior:'smooth'});
  };
  window.renderDashboard=()=>{
    const today=new Date().toDateString();
    $('#dashToday').textContent=visits.filter(v=>new Date(v.checkIn).toDateString()===today).length;
    $('#dashOnsite').textContent=visits.filter(v=>!v.checkOut).length;
    $('#dashDeparted').textContent=visits.filter(v=>v.checkOut&&new Date(v.checkOut).toDateString()===today).length;
    $('#dashTotal').textContent=visits.length;
    const recent=$('#recentArrivals');recent.replaceChildren();
    if(!visits.length){const empty=document.createElement('div');empty.className='dashboard-empty';empty.innerHTML='<span>↗</span><h3>Ready for the first arrival</h3><p>Registered visitors will appear here. Start by scanning an identity document.</p>';recent.append(empty);}
    for(const v of visits.slice(0,4)) {const row=document.createElement('div');row.className='arrival-row';const avatar=document.createElement('span');avatar.className='arrival-avatar';avatar.textContent=v.name.trim().slice(0,1).toUpperCase();const info=document.createElement('div');const name=document.createElement('strong');name.textContent=v.name;const detail=document.createElement('small');detail.textContent=v.company||v.host;info.append(name,detail);const time=document.createElement('span');time.className='arrival-time';time.textContent=new Date(v.checkIn).toLocaleString([],{month:'short',day:'numeric',hour:'2-digit',minute:'2-digit'});const badge=document.createElement('span');badge.className='arrival-status';badge.textContent=v.checkOut?'Checked out':'On site';row.append(avatar,info,time,badge);recent.append(row);}
    const scans=window.scanDocuments.values();const draft=$('#draftProgress');draft.replaceChildren();
    for(const [label,done] of [['Front of ID',!!scans.documentFront],['Back of ID',!!scans.documentBack],['Visitor photo',!!photo],['Visitor details',!!form.elements.name.value.trim()&&!!form.elements.idNumber.value.trim()]]){const row=document.createElement('div');row.className=done?'draft-item complete':'draft-item';const text=document.createElement('span');text.textContent=label;const status=document.createElement('strong');status.textContent=done?'Ready ✓':'Pending';row.append(text,status);draft.append(row);}
  };
  for(const [name,button] of Object.entries(navs))button.onclick=()=>name==='log'?showLog():openWorkspace(name);
  document.querySelectorAll('[data-page]').forEach(button=>button.onclick=()=>button.dataset.page==='log'?showLog():openWorkspace(button.dataset.page));
  $('#newVisit').onclick=()=>openWorkspace('scan');
  $('.brand').onclick=e=>{e.preventDefault();openWorkspace('dashboard');};
  openWorkspace('dashboard');
})();
