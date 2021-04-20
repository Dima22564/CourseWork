<template>
  <div>
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
    >
      <template v-slot:top>
        <div class="flex justify-between flex-center" style="width: 100%">
          <h6 class="q-ma-none">Контактные лица</h6>
          <q-btn class="q-ml-auto q-mr-sm" @click="addContactPerson = true" v-if="isShowAddContactPersonBtn" size="sm" color="secondary" :icon="icons.mdiPlus" label="добавить контактное лица" />
          <q-btn @click="createContactPerson = true" size="sm" color="primary" :icon="icons.mdiPencil" label="создать контактное лица" />
        </div>
      </template>
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="tin" :props="props">
            {{ props.row.tin }}
            <q-popup-edit
              v-model="props.row.tin"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.tin" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              v-model="props.row.name"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.name" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="partner" :props="props">
            {{ props.row.partner }}
            <q-popup-edit
              v-model="props.row.partner"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.partner" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="phone" :props="props">
            {{ props.row.phone }}
            <q-popup-edit
              v-model="props.row.phone"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.hiringDate" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="email" :props="props">
            {{ props.row.email }}
            <q-popup-edit
              v-model="props.row.email"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.email" dense autofocus counter />
            </q-popup-edit>
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.employeeId)" :loading="loading" />
            <q-btn class="q-ml-sm" color="secondary" size="sm" label="Просмотр" @click="getPartner(props.row.employeeId)" :loading="loading" />
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <q-dialog v-model="addContactPerson" v-if="isShowAddContactPersonBtn" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Добавление контактного лица.</span>
        </q-card-section>

        <AddBankAccountPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>

    <q-dialog v-model="createContactPerson" persistent>
      <q-card style="width: 700px;">
        <q-card-section class="row items-center justify-between">
          <span class="q-ma-none text-h6">Создание контактного лица.</span>
        </q-card-section>

        <AddBankAccountPopup />

        <q-card-actions align="right">
          <q-btn flat label="Закрыть" color="primary" v-close-popup />
        </q-card-actions>
      </q-card>
    </q-dialog>
  </div>
</template>

<script>
import AddBankAccountPopup from 'components/addingElements/AddBankAccountPopup'
import icons from 'src/mixins/icons'

export default {
  name: 'ContactPeopleTable',
  components: {
    AddBankAccountPopup
  },
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => []
    },
    isShowAddContactPersonBtn: {
      type: Boolean,
      default: () => false
    }
  },
  methods: {
    saveChanges (partnerId) {
    },
    getPartner (partnerId) {
      this.$router.push('/partner/' + partnerId + '?tab=partnerInfo')
    }
  },
  data: () => {
    return {
      loading: false,
      addContactPerson: false,
      createContactPerson: false,
      columns: [
        { name: 'tin', label: 'ИНН', align: 'left', field: 'tin' },
        { name: 'name', label: 'Полное имя', field: 'name' },
        { name: 'partner', label: 'Партнер', field: 'partner' },
        { name: 'phone', label: 'Телефон', field: 'phone' },
        { name: 'email', label: 'Email', field: 'email' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  }
}
</script>
