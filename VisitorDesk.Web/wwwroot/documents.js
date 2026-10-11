(() => {
  let selected = null, draft = {}, version = 0, loadVersion = 0;
  const selectors = [], summaries = [];
  const controls = () => [...document.querySelectorAll('[data-document-field]')];
  function fields() {
    return {...Object.fromEntries(controls().map(input => [input.dataset.documentField,input.value])),
      template:$('#documentTemplate').value,identityType:$('#documentIdentityType').value,
      cardType:$('#cardType').value,cardNumber:$('#cardNumber').value};
  }
  function populate(data={}) {
    controls().forEach(input=>input.value=data[input.dataset.documentField]||'');
    $('#documentTemplate').value=data.template||'visitor';$('#documentIdentityType').value=data.identityType||'qid';
    $('#cardType').value=data.cardType||'VISITOR';$('#cardNumber').value=data.cardNumber||'';
    visibleFields();
  }
  function visibleFields() {
    const visitor=new Set(['area','visitDate','departmentManager','productionManager','securityController']);
    const common=new Set(['title','duration']);
    controls().forEach(input=>{
      input.closest('label').hidden=!common.has(input.dataset.documentField) && (visitor.has(input.dataset.documentField)!==($('#documentTemplate').value==='visitor'));
    });
  }
  function invalidate(){version++;window.clearDocumentPreviews();}
  function summary() {
    const data=selected||values();
    summaries.forEach(el=>el.textContent=`${selected?'Saved registration':'Current draft'}: ${data.name||'No visitor selected'}${data.idNumber?' · '+data.idNumber:''}`);
    document.querySelectorAll('.save-document-fields').forEach(button=>button.hidden=!selected);
  }
  async function select(id) {
    const request=++loadVersion;
    const record=id?await api(`/api/visits/${id}`):null;
    if(request!==loadVersion)return;
    if(!selected)draft=fields();
    selected=record;populate(record?record.documentFields:draft);invalidate();
    selectors.forEach(select=>select.value=id||'');summary();
  }
  function enter() {
    for(const select of selectors){
      const id=selected?.id||'';select.replaceChildren(new Option('Current registration draft',''));
      for(const visit of visits)select.add(new Option(`${visit.name} · ${new Date(visit.checkIn).toLocaleString()}`,visit.id));
      select.value=id;
    }
    summary();
  }
  for(const section of ['documents','cards']) {
    const panel=document.createElement('div');panel.className='document-source card';
    const label=document.createElement('label');label.textContent='Prepare for';
    const selectNode=document.createElement('select');selectNode.setAttribute('aria-label',`${section} registration source`);
    selectNode.onchange=async()=>{try{await select(selectNode.value);}catch(error){notify(error.message);enter();}};
    label.append(selectNode);selectors.push(selectNode);
    const description=document.createElement('p');summaries.push(description);
    const save=document.createElement('button');save.className='button secondary save-document-fields';save.textContent='Save document details';save.hidden=true;
    save.onclick=async()=>{if(!selected)return;save.disabled=true;const id=selected.id,data=fields();try{await api(`/api/visits/${id}/documents`,{method:'PUT',headers:{'Content-Type':'application/json'},body:JSON.stringify(data)});if(selected?.id===id)selected.documentFields=data;notify('Document details saved.');}catch(error){notify(error.message);}finally{save.disabled=false;}};
    panel.append(label,description,save);$(`#${section} .heading`).after(panel);
  }
  // Enumerated answers avoid accidentally recording an unanswered question as No.
  const felony=$('[data-document-field="felony"]');const answer=document.createElement('select');answer.dataset.documentField='felony';
  for(const option of ['','Yes','No'])answer.add(new Option(option||'Not answered',option));felony.replaceWith(answer);
  const update=()=>{if(!selected){dirty=true;draft=fields();}invalidate();visibleFields();summary();};
  $('#documents').addEventListener('input',update);$('#cards').addEventListener('input',update);
  form.addEventListener('input',()=>{if(!selected){invalidate();summary();}});
  $('#checkChip').onclick=async()=>{
    const button=$('#checkChip');button.disabled=true;$('#chipMessage').textContent='Checking connected readers…';$('#chipReaders').replaceChildren();
    try{const result=await api('/api/chip/status');$('#chipMessage').textContent=result.readers.length?result.message:'No card readers detected. Connect the reader and check again.';
      for(const reader of result.readers){const item=document.createElement('p');item.textContent=`${reader.name} — ${reader.cardConnected?'Card connected':'No accessible card'}`;$('#chipReaders').append(item);}
    }catch(error){$('#chipMessage').textContent=error.message;}finally{button.disabled=false;}
  };
  window.documentWorkflow={
    get version(){return version;},invalidate,enter,select,
    draftFields:()=>selected?draft:fields(),
    reset:()=>{loadVersion++;selected=null;draft={};populate();invalidate();enter();},
    payload:card=>{
      const record=selected||{...values(),photo,...window.scanDocuments.values(),signature:signed?canvas.toDataURL():''};
      const identity=Object.fromEntries(['name','idNumber','nationality','dob','expiry','phone','company','host','purpose','photo','documentFront','documentBack','signature'].map(key=>[key,record[key]||'']));
      return {...identity,...fields(),template:card?'card':$('#documentTemplate').value};
    }
  };
  visibleFields();enter();
})();
